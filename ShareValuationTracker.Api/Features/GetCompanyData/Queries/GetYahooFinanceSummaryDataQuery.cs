using Placeholder.API.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace Placeholder.API.Features.GetCompanyData.Queries
{
    public class GetYahooFinanceSummaryDataQuery : Query<YahooFinanceSummaryData> 
    {
        public string StockCode { get; set; }
    }
}
