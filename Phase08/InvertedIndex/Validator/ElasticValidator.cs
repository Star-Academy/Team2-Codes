using Elasticsearch.Net;

namespace Validator
{
    public static class ElasticValidator
    {
        public static ValidationResult ValidateElasticResponse(IElasticsearchResponse response)
        {
            return response.ApiCall.Success
                ? new ValidationResult {IsValid = true, ElasticException = null}
                : new ValidationResult {IsValid = false, ElasticException = response.ApiCall.OriginalException};
        }
    }
}