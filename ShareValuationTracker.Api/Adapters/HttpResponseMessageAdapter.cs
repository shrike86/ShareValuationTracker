using System.Net;

namespace Placeholder.API.Adapters
{
    public class HttpResponseMessageAdapter : IHttpResponseMessage
    {
        private readonly HttpResponseMessage _httpResponseMessage;

        public HttpResponseMessageAdapter(HttpResponseMessage httpResponseMessage)
        {
            _httpResponseMessage = httpResponseMessage;
        }

        public IHttpContent Content => new HttpContentAdapter(_httpResponseMessage.Content);

        public bool IsSuccessStatusCode => _httpResponseMessage.IsSuccessStatusCode;

        public HttpStatusCode StatusCode => _httpResponseMessage.StatusCode;
    }
}
