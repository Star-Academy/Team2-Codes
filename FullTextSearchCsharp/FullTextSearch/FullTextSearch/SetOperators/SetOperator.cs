using System;
using System.Collections.Generic;
using System.Linq;
using FullTextSearch.Model;

namespace FullTextSearch.SetOperators
{
    public abstract class SetOperator
    {
        public ISet<string> Operate(ISet<string> result, List<string> queryWords, InvertedIndex invertedIndex)
        {
            ISet<string> answer = new HashSet<string>(result);

            if (queryWords != null && queryWords.Any())
            {
                foreach (var word in queryWords)
                {
                    ISet<string> idSet = new HashSet<string> (invertedIndex.Indexes[word]);
                    if (idSet.Any())
                    {
                        SpecificOperation(answer, idSet);
                    }
                }
            }

            return answer;

        }

        public abstract void SpecificOperation(ISet<string> result, ISet<string> idSet);
    }
}