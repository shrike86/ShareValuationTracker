using Placeholder.API.Adapters;

namespace Placeholder.API.Services.Http
{
    public class HttpResponseMessageWrapper : IHttpResponseMessageWrapper
    {
        public IHttpResponseMessage Wrap(HttpResponseMessage response)
            => new HttpResponseMessageAdapter(response);
    }
}
