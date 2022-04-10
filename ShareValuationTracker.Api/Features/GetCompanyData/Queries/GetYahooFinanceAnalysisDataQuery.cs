using ShareValuationTracker.Api.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace ShareValuationTracker.Api.Features.GetCompanyData.Queries
{
    public class GetYahooFinanceAnalysisDataQuery : Query<YahooFinanceAnalysisData>
    {
        public string StockCode { get; set; }
    }
}
