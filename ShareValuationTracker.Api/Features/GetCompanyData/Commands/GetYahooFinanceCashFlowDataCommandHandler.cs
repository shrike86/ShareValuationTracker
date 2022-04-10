using HtmlAgilityPack;
using Placeholder.API.Features.GetCompanyData.Models;
using Placeholder.API.Services.Yahoo;
using SimpleSoft.Mediator;

namespace Placeholder.API.Features.GetCompanyData.Commands
{
    public class GetYahooFinanceCashFlowDataCommandHandler : ICommandHandler<GetYahooFinanceCashFlowDataCommand, YahooFinanceCashflowData>
    {
        private readonly IYahooFinanceService _yahooFinanceService;
        private readonly IYahooFinanceDataSelector _companyDataSelector;

        public GetYahooFinanceCashFlowDataCommandHandler(
            IYahooFinanceService yahooFinanceService, 
            IYahooFinanceDataSelector companyDataSelector)
        {
            _yahooFinanceService = yahooFinanceService;
            _companyDataSelector = companyDataSelector;
        }

        public async Task<YahooFinanceCashflowData> HandleAsync(GetYahooFinanceCashFlowDataCommand cmd, CancellationToken ct)
        {
            var cashFlowStream = await _yahooFinanceService.GetYahooCashflowStreamByCompany(cmd.StockCode);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(cashFlowStream);

            return new YahooFinanceCashflowData 
            {
                FreeCashFlowTrailingTwelveMonths = _companyDataSelector.GetFreeCashFlowTrailingTwelveMonthsFromCashFlowStream(htmlDoc)
            };
        }
    }
}
