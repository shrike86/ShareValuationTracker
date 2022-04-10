using Placeholder.API.Features.GetCompanyData;
using Placeholder.API.Features.GetCompanyData.Models;

namespace Placeholder.API
{
    public static class Constants
    {
        public static class Companies 
        { 
            public static List<Company> Asx = new List<Company>
            {
                new(){ Name = "Woodside", StockCode = "WPL"} 
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
        }
    }
}
