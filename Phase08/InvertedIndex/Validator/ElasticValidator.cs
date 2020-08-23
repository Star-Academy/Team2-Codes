using Nest;

namespace Validator
{
    public static class ElasticValidator
    {
        public static ValidationResult ValidateElasticResponse(IResponse response)
        {
            return response.ApiCall.Success && response.IsValid
                ? new ValidationResult {IsValid = true, ElasticException = null , HttpStatusCode = response.ApiCall.HttpStatusCode}
                : new ValidationResult {IsValid = false, ElasticException = response.ApiCall.OriginalException , HttpStatusCode = response.ApiCall.HttpStatusCode };
        }
    }
}