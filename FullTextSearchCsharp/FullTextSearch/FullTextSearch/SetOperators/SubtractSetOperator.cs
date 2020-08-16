using System.Collections.Generic;

namespace FullTextSearch.SetOperators
{
    public class SubtractSetOperator : SetOperator
    {
        public override void SpecificOperation(ISet<string> result, ISet<string> idSet)
        {
            result.ExceptWith(idSet);
        }
    }
}