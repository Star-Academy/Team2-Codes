using Nest;
using Validator.Exceptions;

namespace Validator
{
    public static class ElasticValidator
    {
        public static ValidationResult ValidateElasticResponse(IResponse response)
        {
            if (response.ApiCall.Success && response.IsValid)
            {
                return new ValidationResult
                    {IsValid = true, ElasticException = null, HttpStatusCode = response.ApiCall.HttpStatusCode};
            }

            if (response.ServerError != null)
            {
                return new ValidationResult
                {
                    IsValid = false, ElasticException = new ElasticServerException(response.ServerError.ToString()),
                    HttpStatusCode = response.ApiCall.HttpStatusCode
                };
            }

            if (response.ApiCall.OriginalException != null)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ElasticException = new ElasticClientException(response.ApiCall.OriginalException.Message),
                    HttpStatusCode = response.ApiCall.HttpStatusCode
                };
            }

            return new ValidationResult
            {
                IsValid = false, ElasticException = new ElasticClientException(),
                HttpStatusCode = response.ApiCall.HttpStatusCode
            };
        }
    }
}