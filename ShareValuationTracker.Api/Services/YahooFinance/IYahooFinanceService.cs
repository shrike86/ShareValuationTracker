namespace Placeholder.API.Services.Yahoo
{
    public interface IYahooFinanceService
    {
        Task<Stream> GetYahooSummaryStreamByCompany(string stockCode);
    }
}
