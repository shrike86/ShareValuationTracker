using System.Net;

namespace Placeholder.API.Adapters
{
    public interface IHttpResponseMessage
    {
        IHttpContent Content { get; }
        bool IsSuccessStatusCode { get; }
        HttpStatusCode StatusCode { get; }
    }
}
