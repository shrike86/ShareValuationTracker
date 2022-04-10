using Placeholder.API.Adapters;

namespace Placeholder.API.Services.Http
{
    public interface IHttpResponseMessageParser
    {
        Task<T> ParseAsync<T>(IHttpResponseMessage response);
    }
}
