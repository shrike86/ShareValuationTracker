namespace Placeholder.API.Services.YahooFinance
{
    public class EndpointUtility : IEndpointUtility
    {
        public string GetYahooSummary(string baseUrl, string stockCode)
        {
            string shareCode = $"{stockCode}.{Constants.YahooMarketAcronyms.Asx}";

            return $"{baseUrl}quote/{shareCode}?p={shareCode}&tsrc=fin-srch";
        }
    }
}
