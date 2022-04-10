using SimpleSoft.Mediator;

namespace ShareValuationTracker.Api.Features.CalculateDiscountedCashFlow.Queries
{
    public class CalculateDiscountedCashFlowQueryHandler : IQueryHandler<CalculateDiscountedCashFlowQuery, double>
    {
        public async Task<double> HandleAsync(CalculateDiscountedCashFlowQuery query, CancellationToken ct)
        {
            decimal.TryParse(query.DefaultGrowthRatePercentage, out var defaultGrowthRatePercentage);
            decimal defaultGrowthRate = defaultGrowthRatePercentage / 100;

            long finalDiscountedCashFlow = 0;

            decimal yearlyCashFlow = query.FreeCashFlowTrailingTwelveMonths;

            for (int i = 1; i <= query.DefaultNumberOfYears; i++)
            {
                yearlyCashFlow += i > 1 ? (yearlyCashFlow * defaultGrowthRate) : 0;

                decimal numerator = Math.Round(yearlyCashFlow);
                double denominator = Math.Round(Math.Pow((double)(1 + query.DefaultDiscountRate), i), 5);
                double discountedCashFlow = (double)numerator / denominator;
                long discountedCashFlowRounded = (long)Math.Round((double)discountedCashFlow);

                finalDiscountedCashFlow += discountedCashFlowRounded;
            }

            return finalDiscountedCashFlow * 1000;
        }
    }
}
