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
                return NoErroResult(response);
            }

            if (response.ServerError != null)
            {
                return ServerErrorResult(response);
            }

            if (response.ApiCall.OriginalException != null)
            {
                return ClientErrorResult(response);
            }

            return UnknownErrorResult(response);
        }

        public static ValidationResult NoErroResult(IResponse response)
        {
            return new ValidationResult
                {IsValid = true, ElasticException = null, HttpStatusCode = response.ApiCall.HttpStatusCode};
        }

        public static ValidationResult ServerErrorResult(IResponse response)
        {
            return new ValidationResult
            {
                IsValid = false,
                ElasticException = new ElasticServerException(response.ServerError.ToString()),
                HttpStatusCode = response.ApiCall.HttpStatusCode
            };
        }

        public static ValidationResult ClientErrorResult(IResponse response)
        {
            return new ValidationResult
            {
                IsValid = false,
                ElasticException = new ElasticClientException(response.OriginalException.Message),
                HttpStatusCode = response.ApiCall.HttpStatusCode
            };
        }

        public static ValidationResult UnknownErrorResult(IResponse response)
        {
            return new ValidationResult
            {
                IsValid = false,
                ElasticException = new ElasticClientException(),
                HttpStatusCode = response.ApiCall.HttpStatusCode
            };
        }
    }
}