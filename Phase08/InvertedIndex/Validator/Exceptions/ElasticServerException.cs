using System;
using System.Runtime.Serialization;

namespace Validator.Exceptions
{
    [Serializable]
    public class ElasticServerException : BaseElasticException
    {
        public ElasticServerException(string message) : base( message)
        {
        }

        public ElasticServerException() : base("Some Unknown Server Error Occured")
        {
        }

        
        public ElasticServerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ElasticServerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}