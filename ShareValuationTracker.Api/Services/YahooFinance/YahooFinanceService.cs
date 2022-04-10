using Placeholder.API.Services.Http;
using Placeholder.API.Services.YahooFinance;

namespace Placeholder.API.Services.Yahoo
{
    public class YahooFinanceService : IYahooFinanceService
    {
        private readonly HttpClient _httpClient;
        private readonly IBaseHttpService _baseHttpService;
        private readonly IEndpointUtility _endpointUtility;

        public YahooFinanceService(
            IHttpClientFactory httpClientFactory,
            IBaseHttpService baseHttpService,
            IEndpointUtility endpointUtility)
        {
            _httpClient = httpClientFactory.CreateClient("YahooFinance");
            _baseHttpService = baseHttpService;
            _endpointUtility = endpointUtility;
        }
        public async Task<Stream> GetYahooSummaryStreamByCompany(string stockCode)
        {
            return await _baseHttpService.GetStreamAsync(_httpClient!, _endpointUtility.GetYahooSummary(stockCode));
        }

        public async Task<Stream> GetYahooCashflowStreamByCompany(string stockCode)
        {
            return await _baseHttpService.GetStreamAsync(_httpClient!, _endpointUtility.GetYahooCashFlow(stockCode));
        }
    }
}
