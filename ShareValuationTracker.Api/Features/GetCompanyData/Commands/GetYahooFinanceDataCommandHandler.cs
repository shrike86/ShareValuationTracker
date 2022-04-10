using Placeholder.API.Features.GetCompanyData.Commands;
using ShareValuationTracker.Api.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace ShareValuationTracker.Api.Features.GetCompanyData.Commands
{
    public class GetYahooFinanceDataCommandHandler : ICommandHandler<GetYahooFinanceDataCommand, YahooFinanceData>
    {
        private readonly IMediator _mediator;

        public GetYahooFinanceDataCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<YahooFinanceData> HandleAsync(GetYahooFinanceDataCommand cmd, CancellationToken ct)
        {
            var summaryData = await _mediator.SendAsync(new GetYahooFinanceSummaryDataCommand { StockCode = cmd.StockCode}, ct);
            var cashFlowData = await _mediator.SendAsync(new GetYahooFinanceCashFlowDataCommand { StockCode = cmd.StockCode }, ct);

            return new YahooFinanceData
            { 
                EarningsPerShare = summaryData.EarningsPerShare,
                PreviousCloseSharePrice = summaryData.PreviousCloseSharePrice,
                FreeCashFlowTrailingTwelveMonths = cashFlowData.FreeCashFlowTrailingTwelveMonths
            };
        }
    }
}
