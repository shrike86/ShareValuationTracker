using Placeholder.API.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace Placeholder.API.Features.GetCompanyData.Queries
{
    public class GetYahooFinanceCashFlowDataQuery : Query<YahooFinanceCashflowData>
    {
        public string StockCode { get; set; }
    }
}
