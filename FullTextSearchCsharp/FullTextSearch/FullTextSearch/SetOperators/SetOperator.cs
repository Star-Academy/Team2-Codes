using System.Collections.Generic;
using FullTextSearch.Model;

namespace FullTextSearch.SetOperators
{
    public abstract class SetOperator
    {
        public ISet<string> Operate(ISet<string> result, List<string> queryWords, InvertedIndex invertedIndex)
        {
            ISet<string> answer = new HashSet<string>(result);

            if (queryWords is null) return answer;

            foreach (var word in queryWords)
            {
                if (invertedIndex.Indexes.TryGetValue(word,out var idSet))
                {
                    SpecificOperation(answer, idSet);
                }
            }

            return answer;
        }

        public abstract void SpecificOperation(ISet<string> result, ISet<string> idSet);
    }
}