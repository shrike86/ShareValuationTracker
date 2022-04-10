namespace Placeholder.API.Exceptions
{
    [Serializable]
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException() : base($"Internal server error occurred")
        {

        }
    }
}
