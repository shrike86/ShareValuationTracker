namespace Placeholder.API.Services.Yahoo
{
    public interface IYahooFinanceService
    {
        Task<Stream> GetYahooSummaryStreamByCompany(string stockCode);
        Task<Stream> GetYahooCashflowStreamByCompany(string stockCode);
        Task<Stream> GetYahooAnalysisStreamByCompany(string stockCode);
    }
}
