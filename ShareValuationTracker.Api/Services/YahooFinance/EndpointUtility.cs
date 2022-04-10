namespace Placeholder.API.Services.YahooFinance
{
    public class EndpointUtility : IEndpointUtility
    {
        public string GetYahooSummary(string stockCode)
        {
            string shareCode = $"{stockCode}.{Constants.YahooMarketAcronyms.Asx}";

            return $"quote/{shareCode}?p={shareCode}&tsrc=fin-srch";
        }

        public string GetYahooCashFlow(string stockCode)
        {
            string shareCode = $"{stockCode}.{Constants.YahooMarketAcronyms.Asx}";

            return $"quote/{shareCode}/cash-flow?p={shareCode}";
        }

        public string GetYahooAnalysis(string stockCode)
        {
            string shareCode = $"{stockCode}.{Constants.YahooMarketAcronyms.Asx}";

            return $"quote/{shareCode}/analysis?p={shareCode}";
        }
    }
}
