using HtmlAgilityPack;
using Placeholder.API.Features.GetCompanyData.Models;
using Placeholder.API.Services.Yahoo;
using SimpleSoft.Mediator;

namespace Placeholder.API.Features.GetCompanyData.Queries
{
    public class GetYahooFinanceSummaryDataQueryHandler : IQueryHandler<GetYahooFinanceSummaryDataQuery, YahooFinanceSummaryData>
    {
        private readonly IYahooFinanceService _yahooFinanceService;
        private readonly IYahooFinanceDataSelector _companyDataProvider;

        public GetYahooFinanceSummaryDataQueryHandler(
            IYahooFinanceService yahooFinanceService, 
            IYahooFinanceDataSelector companyDataProvider)
        {
            _yahooFinanceService = yahooFinanceService;
            _companyDataProvider = companyDataProvider;
        }


        public async Task<YahooFinanceSummaryData> HandleAsync(GetYahooFinanceSummaryDataQuery query, CancellationToken ct)
        {
            var summaryStream = await _yahooFinanceService.GetYahooSummaryStreamByCompany(query.StockCode);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(summaryStream);

            return new YahooFinanceSummaryData
            {
                MarketCapitalization = _companyDataProvider.GetMarketCapitalizationFromSummaryStream(htmlDoc),
                PreviousCloseSharePrice = _companyDataProvider.GetPreviousCloseSharePriceFromSummaryStream(htmlDoc),
                EarningsPerShare = _companyDataProvider.GetEarningsPerShareFromSummaryStream(htmlDoc)
            };
        }
    }
}
