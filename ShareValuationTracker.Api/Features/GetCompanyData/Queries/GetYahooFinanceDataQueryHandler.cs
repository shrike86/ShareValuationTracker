using Placeholder.API.Features.GetCompanyData.Queries;
using ShareValuationTracker.Api.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace ShareValuationTracker.Api.Features.GetCompanyData.Queries
{
    public class GetYahooFinanceDataQueryHandler : IQueryHandler<GetYahooFinanceDataQuery, YahooFinanceData>
    {
        private readonly IMediator _mediator;

        public GetYahooFinanceDataQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<YahooFinanceData> HandleAsync(GetYahooFinanceDataQuery cmd, CancellationToken ct)
        {
            var summaryData = await _mediator.FetchAsync(new GetYahooFinanceSummaryDataQuery { StockCode = cmd.StockCode}, ct);
            var cashFlowData = await _mediator.FetchAsync(new GetYahooFinanceCashFlowDataQuery { StockCode = cmd.StockCode }, ct);
            var analysisData = await _mediator.FetchAsync(new GetYahooFinanceAnalysisDataQuery { StockCode = cmd.StockCode }, ct);

            return new YahooFinanceData
            {
                MarketCapitalization = summaryData.MarketCapitalization?.Remove(summaryData.MarketCapitalization.Length - 1),
                EarningsPerShare = summaryData.EarningsPerShare,
                PreviousCloseSharePrice = summaryData.PreviousCloseSharePrice,
                FreeCashFlowTrailingTwelveMonths = cashFlowData.FreeCashFlowTrailingTwelveMonths,
                ProjectedFiveYearGrowthPercentage = analysisData.ProjectedFiveYearGrowthPercentage
            };
        }
    }
}
