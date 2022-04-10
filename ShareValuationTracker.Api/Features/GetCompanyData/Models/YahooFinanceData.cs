namespace ShareValuationTracker.Api.Features.GetCompanyData.Models
{
    public class YahooFinanceData
    {
        public string MarketCapitalization { get; set; }
        public string PreviousCloseSharePrice { get; set; }
        public string EarningsPerShare { get; set; }
        public string ProjectedFiveYearGrowthPercentage { get; set; }
        public string FreeCashFlowTrailingTwelveMonths { get; set; }
    }
}
