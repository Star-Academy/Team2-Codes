using System;
using System.Collections.Generic;
using System.Text;

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
