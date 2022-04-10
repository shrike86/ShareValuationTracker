using Placeholder.API.Adapters;

namespace Placeholder.API.Services.Http
{
    public interface IHttpResponseMessageWrapper
    {
        IHttpResponseMessage Wrap(HttpResponseMessage response);
    }
}
