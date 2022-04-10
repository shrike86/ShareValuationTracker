using Placeholder.API.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace Placeholder.API.Features.GetCompanyData.Commands
{
    public class GetYahooFinanceSummaryDataCommand : Command<YahooFinanceSummaryData> 
    {
        public string StockCode { get; set; }
    }
}
