namespace ShareValuationTracker.Api.Features.GetCompanyData.Models
{
    public class YahooFinanceData
    {
        public string PreviousCloseSharePrice { get; set; }
        public string EarningsPerShare { get; set; }
        public string FreeCashFlowTrailingTwelveMonths { get; set; }
    }
}
