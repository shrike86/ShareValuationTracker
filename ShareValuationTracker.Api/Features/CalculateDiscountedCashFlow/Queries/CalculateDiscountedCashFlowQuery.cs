using SimpleSoft.Mediator;

namespace ShareValuationTracker.Api.Features.CalculateDiscountedCashFlow.Queries
{
    public class CalculateDiscountedCashFlowQuery : Query<double>
    {
        public long FreeCashFlowTrailingTwelveMonths { get; set; }
        public string DefaultGrowthRatePercentage { get; set; }
        public decimal DefaultDiscountRate { get; set; }
        public int DefaultNumberOfYears { get; set; }
    }
}
