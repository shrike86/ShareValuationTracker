namespace Placeholder.API.Adapters
{
    public interface IJsonConvert
    {
        string SerializeObject(object value);
        T DeserializeObject<T>(string value);
    }
}
