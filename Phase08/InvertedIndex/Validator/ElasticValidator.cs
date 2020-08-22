
using Elasticsearch.Net;

namespace Validator
{
    public class ElasticValidator
    {
        public ValidationResult ValidateElasticResponse(IElasticsearchResponse response)
        {
            if (response.ApiCall.Success)
            {
                return new ValidationResult { IsValid = true, ElasticException = null };
            }
            else
            {
                return new ValidationResult { IsValid = false, ElasticException = response.ApiCall.OriginalException };
            }
        }
    }
}