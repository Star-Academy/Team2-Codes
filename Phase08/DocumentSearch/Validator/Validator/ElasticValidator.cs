using System;
using System.Collections.Generic;
using System.Text;

namespace Validator
{
    class Class1
    {
 ElasticValidator
    {
        public ValidationResult ValidateElasticResponse(IElasticsearchResponse response)
        {
            if (response.ApiCall.Success)
            {
                return new ValidationResult{IsValid = true , ElasticException = null};
            }
            else
            {
                return new ValidationResult{IsValid = false , ElasticException = response.ApiCall.OriginalException};
            }
        }
    }
}
