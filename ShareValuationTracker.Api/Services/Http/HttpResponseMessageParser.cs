using Placeholder.API.Adapters;
using Placeholder.API.Exceptions;

namespace Placeholder.API.Services.Http
{
    public class HttpResponseMessageParser : IHttpResponseMessageParser
    {
        private readonly IJsonConvert _jsonConvert;

        public HttpResponseMessageParser(IJsonConvert jsonConvert)
        {
            _jsonConvert = jsonConvert;
        }

        public async Task<T> ParseAsync<T>(IHttpResponseMessage response)
        {
            string responseContent = await GetResponseContent(response);

            if (response.IsSuccessStatusCode)
            {
                return ResponseIsSuccess<T>(response, responseContent);
            }

            return ResponseIsFailure<T>(response, responseContent);
        }

        private async Task<string> GetResponseContent(IHttpResponseMessage response)
        {
            var responseContent = "";

            if (response.Content != null)
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }

            return responseContent;
        }

        private T ResponseIsSuccess<T>(IHttpResponseMessage response, string responseContent)
        {
            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(responseContent, typeof(T));
            }

            return _jsonConvert.DeserializeObject<T>(responseContent);
        }

        private T ResponseIsFailure<T>(IHttpResponseMessage response, string responseContent)
        {
            throw new InternalServerErrorException();
        }
    }
}
