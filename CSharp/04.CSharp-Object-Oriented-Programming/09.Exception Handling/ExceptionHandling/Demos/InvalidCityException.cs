using System.Runtime.Serialization;

namespace Demos
{
    [Serializable]
    public class InvalidCityException : Exception
    {
        public InvalidCityException()
        {
        }

        public InvalidCityException(string? message) : base(message)
        {
        }

        public InvalidCityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}