using System;
using System.Runtime.Serialization;

namespace Validator.Exceptions
{
    [Serializable]
    public class ElasticClientException : BaseElasticException
    {
        public ElasticClientException(string message) : base($"Client Error: {message}")
        {
        }

        public ElasticClientException() : base("Some Unknown Client Error Occured")
        {
        }

        public ElasticClientException(string message, Exception innerException) : base($"Client Error: {message}", innerException)
        {
        }

        protected ElasticClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}