namespace Placeholder.API.Services.Http
{
    public class BaseHttpService : IBaseHttpService
    {
        private readonly ILogger<BaseHttpService> _logger;
        private readonly IHttpResponseMessageWrapper _httpResponseMessageWrapper;
        private readonly IHttpResponseMessageParser _httpResponseMessageParser;

        public BaseHttpService(
            ILogger<BaseHttpService> logger,
            IHttpResponseMessageWrapper httpResponseMessageWrapper, 
            IHttpResponseMessageParser httpResponseMessageParser)
        {
            _logger = logger;
            _httpResponseMessageWrapper = httpResponseMessageWrapper;
            _httpResponseMessageParser = httpResponseMessageParser;
        }

        public async Task<TResult> GetAsync<TResult>(HttpClient httpClient, string endpoint)
        {
            _logger.LogInformation($"Calling GET  \"{endpoint}\"");

            HttpResponseMessage response = await httpClient.GetAsync(endpoint);

            return await _httpResponseMessageParser.ParseAsync<TResult>(_httpResponseMessageWrapper.Wrap(response));
        }

        public async Task<Stream> GetStreamAsync(HttpClient httpClient, string endpoint)
        {
            _logger.LogInformation($"Calling GET as stream \"{endpoint}\"");

            var requestUri = new Uri($"{httpClient.BaseAddress}{endpoint}");

            return await httpClient.GetStreamAsync(requestUri);
        }
    }
}
