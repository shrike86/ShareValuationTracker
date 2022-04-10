using ShareValuationTracker.Api.Features.GetCompanyData.Models;
using SimpleSoft.Mediator;

namespace ShareValuationTracker.Api.Features.GetCompanyData.Commands
{
    public class GetYahooFinanceDataCommand : Command<YahooFinanceData>
    {
        public string StockCode { get; set; }
    }
}
