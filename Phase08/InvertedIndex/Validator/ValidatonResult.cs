using System;

namespace Validator
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public Exception ElasticException { get; set; }

        public int? HttpStatusCode { get; set; }


    }
}