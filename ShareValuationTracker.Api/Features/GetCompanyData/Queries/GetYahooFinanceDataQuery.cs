using ShareValuationTracker.Api.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace ShareValuationTracker.Api.Features.GetCompanyData.Queries
{
    public class GetYahooFinanceDataQuery : Query<YahooFinanceData>
    {
        public string StockCode { get; set; }
    }
}
