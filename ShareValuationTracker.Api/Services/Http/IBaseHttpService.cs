namespace Placeholder.API.Services.Http
{
    public interface IBaseHttpService
    {
        Task<TResult> GetAsync<TResult>(HttpClient httpClient, string endpoint);
        Task<Stream> GetStreamAsync(HttpClient httpClient, string url);
    }
}
