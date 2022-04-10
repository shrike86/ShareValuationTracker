using Placeholder.API.Features.GetCompanyData.Models;

namespace Placeholder.API
{
    public static class Constants
    {
        public static class Companies 
        { 
            public static List<Company> Asx = new List<Company>
            {
                new(){ Name = "Commonwealth Bank of Australia", StockCode = "CBA"} ,
                new(){ Name = "CSL Limited", StockCode = "CSL"},
                new(){ Name = "BHP Group Limited", StockCode = "BHP"},
                new(){ Name = "Westpac Banking Corporation", StockCode = "WBC"},
                new(){ Name = "Woodside Petroleum Ltd", StockCode = "WPL"} 
            };
        }

        public static class YahooMarketAcronyms
        {
            public const string Asx = "AX";
        }

        public static class YahooMarketXPaths
        {
            public const string PreviousCloseSharePrice = "//body//div[@id='quote-header-info']//fin-streamer";
            public const string EarningsPerShare = "//body//div[@data-test='right-summary-table']//td";
            public const string FreeCashFlowTrailingTwelveMonths = "//body//div[@id='Main']//div[@data-test='fin-row']";
        }
    }
}
