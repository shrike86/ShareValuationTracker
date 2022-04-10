namespace ShareValuationTracker.Api.Features.GetCompanyData.Models
{
    public class CompanyData
    {
        public string Name { get; set; }
        public string StockCode { get; set; }
        public string PreviousCloseSharePrice { get; set; }
        public string EarningsPerShare { get; set; }
        public string FreeCashFlowTrailingTwelveMonths { get; set; }
    }
}
