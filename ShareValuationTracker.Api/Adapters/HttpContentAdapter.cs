namespace Placeholder.API.Adapters
{
    public class HttpContentAdapter : IHttpContent
    {
        private readonly HttpContent httpContent;

        public HttpContentAdapter(HttpContent httpContent)
        {
            this.httpContent = httpContent;
        }

        public Task<string> ReadAsStringAsync() 
            => httpContent.ReadAsStringAsync();
       
    }
}
