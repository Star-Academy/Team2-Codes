using System;
using System.Runtime.Serialization;

namespace Validator.Exceptions
{
    [Serializable]
    public abstract class BaseElasticException : System.Exception
    {
        protected BaseElasticException(string message) : base(message)
        {
        }

        protected BaseElasticException() : base("Some Unknown Error Occured")
        {
        }

        //This two methods are added to conform to Custom Exception Guidelines
        protected BaseElasticException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BaseElasticException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}