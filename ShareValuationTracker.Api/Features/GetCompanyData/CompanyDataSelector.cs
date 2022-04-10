using Placeholder.API;
using Placeholder.API.Features.GetCompanyData.Models;
using ShareValuationTracker.Api.Features.CalculateDiscountedCashFlow.Queries;
using ShareValuationTracker.Api.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace ShareValuationTracker.Api.Features.GetCompanyData
{
    public class CompanyDataSelector : ICompanyDataSelector
    {
        private readonly IMediator _mediator;

        public CompanyDataSelector(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CompanyData> SelectAsync(Company company, YahooFinanceData yahooFinanceData, CancellationToken ct)
        {
            double.TryParse(yahooFinanceData.PreviousCloseSharePrice, out var sharePrice);
            double.TryParse(yahooFinanceData.MarketCapitalization, out var marketCapShort);
            decimal.TryParse(yahooFinanceData.EarningsPerShare, out var earningsPerShare);
            decimal.TryParse(yahooFinanceData.PreviousCloseSharePrice, out var previousCloseSharePrice);
            long.TryParse(yahooFinanceData.FreeCashFlowTrailingTwelveMonths.Replace(",", ""), out var freeCashFlowTrailingTwelveMonths);

            double marketCap = Math.Round(marketCapShort * 1000000000, 2);
            long sharesOutstanding = (long)Math.Round(marketCap / sharePrice);

            var discountedCashFlow = await _mediator.FetchAsync(new CalculateDiscountedCashFlowQuery
            {
                DefaultNumberOfYears = Constants.DiscountedCashFlowCalculation.DefaultNumberOfYears,
                DefaultDiscountRate = Constants.DiscountedCashFlowCalculation.DefaultDiscountRate,
                FreeCashFlowTrailingTwelveMonths = freeCashFlowTrailingTwelveMonths,
                DefaultGrowthRatePercentage = yahooFinanceData.ProjectedFiveYearGrowthPercentage.Trim('%')
            }, ct);

            return new CompanyData
            {
                Name = company.Name,
                StockCode = company.StockCode,
                PreviousCloseSharePrice = previousCloseSharePrice,
                MarketCapitalization = marketCap,
                SharesOutstanding = sharesOutstanding,
                EarningsPerShare = earningsPerShare,
                FreeCashFlowTrailingTwelveMonths = freeCashFlowTrailingTwelveMonths * 1000,
                DefaultGrowthRatePercentage = yahooFinanceData.ProjectedFiveYearGrowthPercentage,
                DiscountedCashFlow = discountedCashFlow,
                CalculatedSharePrice = Math.Round(discountedCashFlow / sharesOutstanding, 2)
            };
        }
    }
}
