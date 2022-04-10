namespace Placeholder.API.Services.YahooFinance
{
    public interface IEndpointUtility
    {
        string GetYahooSummary(string baseUrl, string stockCode);
    }
}
