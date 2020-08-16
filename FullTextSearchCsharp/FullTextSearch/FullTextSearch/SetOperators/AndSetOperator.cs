using System.Collections.Generic;

namespace FullTextSearch.SetOperators
{
    public class AndSetOperator : SetOperator
    {
        public override void SpecificOperation(ISet<string> result, ISet<string> idSet)
        {
            result.IntersectWith(idSet);
        }
    }
}