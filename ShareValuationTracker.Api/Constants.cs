using Placeholder.API.Features.GetCompanyData.Models;

namespace Placeholder.API
{
    public static class Constants
    {
        public static class DiscountedCashFlowCalculation
        { 
            public const decimal DefaultDiscountRate = 0.15m;
            public const int DefaultNumberOfYears = 5;
        }

        public static class Companies 
        { 
            public static List<Company> Asx200 = new List<Company>
            {
                new(){ Name = "Commonwealth Bank of Australia", StockCode = "CBA"} ,
                new(){ Name = "CSL Limited", StockCode = "CSL"},
                new(){ Name = "BHP Group Limited", StockCode = "BHP"},
                new(){ Name = "Westpac Banking Corporation", StockCode = "WBC"},
                new(){ Name = "National Australia Bank Limited", StockCode = "NAB"},
                new(){ Name = "Australia and New Zealand Banking Group Limited", StockCode = "ANZ"},
                new(){ Name = "Macquarie Group Limited", StockCode = "MQG"},
                new(){ Name = "Wesfarmers Limited", StockCode = "WES"},
                new(){ Name = "Woolworths Group Limited", StockCode = "WOW"},
                new(){ Name = "Telstra Corporation Limited", StockCode = "TLS"},
                new(){ Name = "Transurban Group", StockCode = "TCL"},
                new(){ Name = "Rio Tinto Group", StockCode = "RIO"},
                new(){ Name = "Fortescue Metals Group Limited", StockCode = "FMG"},
                new(){ Name = "Woodside Petroleum Ltd", StockCode = "WPL"},
                new(){ Name = "Goodman Group", StockCode = "GMG"},
                new(){ Name = "Newcrest Mining Limited", StockCode = "NCM"},
                new(){ Name = "Aristocrat Leisure Limited", StockCode = "ALL"},
                new(){ Name = "Scentre Group", StockCode = "SCG"},
                new(){ Name = "Coles Group Limited", StockCode = "COL"},
                //new(){ Name = "Scentre Group", StockCode = "SYD"}, // Not added to yahoo finance yet..
                new(){ Name = "Brambles Limited", StockCode = "BXB"}, 
                new(){ Name = "Insurance Australia Group Limited", StockCode = "IAG"}, 
                new(){ Name = "Santos Limited", StockCode = "STO"}, 
                new(){ Name = "QBE Insurance Group Limited", StockCode = "QBE"}, 
                new(){ Name = "Suncorp Group Limited", StockCode = "SUN"}, 
            };
        }

        public static class YahooMarketAcronyms
        {
            public const string Asx = "AX";
        }

        public static class YahooMarketXPaths
        {
            public const string MarketCapitalization = "//body//div[@data-test='right-summary-table']//td";
            public const string PreviousCloseSharePrice = "//body//div[@id='quote-header-info']//fin-streamer";
            public const string EarningsPerShare = "//body//div[@data-test='right-summary-table']//td";
            public const string FreeCashFlowTrailingTwelveMonths = "//body//div[@id='Main']//div[@data-test='fin-row']";
            public const string ProjectedGrowthRatePercentage = "//body//div[@id='Main']//table//tbody";
        }
    }
}
