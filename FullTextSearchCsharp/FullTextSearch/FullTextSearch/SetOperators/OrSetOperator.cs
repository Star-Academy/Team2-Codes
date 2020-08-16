using System.Collections.Generic;

namespace FullTextSearch.SetOperators
{
    public class OrSetOperator : SetOperator
    {
        public override void SpecificOperation(ISet<string> result, ISet<string> idSet)
        {
            result.UnionWith(idSet);
        }
    }
}
