namespace Placeholder.API.Services.YahooFinance
{
    public interface IEndpointUtility
    {
        string GetYahooSummary(string stockCode);
        string GetYahooCashFlow(string stockCode);
    }
}
