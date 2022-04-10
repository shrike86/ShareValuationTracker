using HtmlAgilityPack;
using Placeholder.API.Features.GetCompanyData;
using Placeholder.API.Services.Yahoo;
using ShareValuationTracker.Api.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace ShareValuationTracker.Api.Features.GetCompanyData.Queries
{
    public class GetYahooFinanceAnalysisDataQueryHandler : IQueryHandler<GetYahooFinanceAnalysisDataQuery, YahooFinanceAnalysisData>
    {
        private readonly IYahooFinanceService _yahooFinanceService;
        private readonly IYahooFinanceDataSelector _companyDataSelector;

        public GetYahooFinanceAnalysisDataQueryHandler(
            IYahooFinanceService yahooFinanceService, 
            IYahooFinanceDataSelector companyDataSelector)
        {
            _yahooFinanceService = yahooFinanceService;
            _companyDataSelector = companyDataSelector;
        }


        public async Task<YahooFinanceAnalysisData> HandleAsync(GetYahooFinanceAnalysisDataQuery query, CancellationToken ct)
        {
            var analysisStream = await _yahooFinanceService.GetYahooAnalysisStreamByCompany(query.StockCode);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(analysisStream);

            return new YahooFinanceAnalysisData
            {
                ProjectedFiveYearGrowthPercentage = 
                    _companyDataSelector.GetProjectedGrowthRatePercentageFromAnalysisStream(htmlDoc)
            };
        }
    }
}
