using Placeholder.API.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace Placeholder.API.Features.GetCompanyData.Commands
{
    public class GetYahooFinanceCashFlowDataCommand : Command<YahooFinanceCashflowData>
    {
        public string StockCode { get; set; }
    }
}
