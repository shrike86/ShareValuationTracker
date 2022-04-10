using HtmlAgilityPack;
using Placeholder.API.Features.GetCompanyData.Models;
using Placeholder.API.Services.Yahoo;
using SimpleSoft.Mediator;

namespace Placeholder.API.Features.GetCompanyData.Queries
{
    public class GetYahooFinanceCashFlowDataQueryHandler : IQueryHandler<GetYahooFinanceCashFlowDataQuery, YahooFinanceCashflowData>
    {
        private readonly IYahooFinanceService _yahooFinanceService;
        private readonly IYahooFinanceDataSelector _companyDataSelector;

        public GetYahooFinanceCashFlowDataQueryHandler(
            IYahooFinanceService yahooFinanceService, 
            IYahooFinanceDataSelector companyDataSelector)
        {
            _yahooFinanceService = yahooFinanceService;
            _companyDataSelector = companyDataSelector;
        }

        public async Task<YahooFinanceCashflowData> HandleAsync(GetYahooFinanceCashFlowDataQuery query, CancellationToken ct)
        {
            var cashFlowStream = await _yahooFinanceService.GetYahooCashflowStreamByCompany(query.StockCode);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(cashFlowStream);

            return new YahooFinanceCashflowData 
            {
                FreeCashFlowTrailingTwelveMonths = _companyDataSelector.GetFreeCashFlowTrailingTwelveMonthsFromCashFlowStream(htmlDoc)
            };
        }
    }
}
