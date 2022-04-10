namespace ShareValuationTracker.Api.Features.GetCompanyData.Models
{
    public class CompanyData
    {
        public string Name { get; set; }
        public string StockCode { get; set; }
        public double MarketCapitalization { get; set; }
        public long SharesOutstanding { get; set; }
        public decimal PreviousCloseSharePrice { get; set; }
        public decimal EarningsPerShare { get; set; }
        public long FreeCashFlowTrailingTwelveMonths { get; set; }
        public double DiscountedCashFlow { get; set; }
        public string DefaultGrowthRatePercentage { get; set; }
        public double CalculatedSharePrice { get; set; }
    }
}
