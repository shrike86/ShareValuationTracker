using Newtonsoft.Json;

namespace Placeholder.API.Adapters
{
    public class JsonConvertAdapter : IJsonConvert
    {
        public string SerializeObject(object value) => JsonConvert.SerializeObject(value);

        public T DeserializeObject<T>(string value) => (T)JsonConvert.DeserializeObject(value);
    }
}
