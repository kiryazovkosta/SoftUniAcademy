using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ValidPerson
{
    internal class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException()
        {
        }

        public InvalidPersonNameException(string message) 
            : base(message)
        {
        }

        public InvalidPersonNameException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected InvalidPersonNameException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
