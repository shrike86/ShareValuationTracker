namespace Placeholder.API.Adapters
{
    public interface IHttpContent
    {
        Task<string> ReadAsStringAsync();
    }
}
