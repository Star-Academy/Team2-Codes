using System.Collections.Generic;
using FullTextSearch.Model;
using FullTextSearch.SetOperators;
using FullTextSearch.Utility;
using System.Linq;

namespace FullTextSearchCsharp.FullTextSearch.FullTextSearch.Utility
{
    public class QueryProcessor
    {
        public InvertedIndex invertedIndex;
        public InputProcessor inputProcessor;

        public QueryProcessor(InvertedIndex invertedIndex, InputProcessor inputProcessor)
        {
            this.invertedIndex = invertedIndex;
            this.inputProcessor = inputProcessor;
        }

        public List<string> PerformSearch(string input)
        {
            inputProcessor.ProcessInput(input);
            var result = PrepareResultSet();
            return DoSearchStrategies(result);
        }

        private ISet<string> PrepareResultSet()
        {
            ISet<string> result = new HashSet<string>(); 
            if (inputProcessor.andStrings.Any())
            {
                var firstWordInAndStrings = inputProcessor.andStrings[0];
                result.UnionWith(invertedIndex.Indexes[firstWordInAndStrings]);
            }
            return result;
        }

        public List<string> DoSearchStrategies(ISet<string> result)
        {
            result = new AndSetOperator().Operate(result, inputProcessor.andStrings, invertedIndex);
            result = new OrSetOperator().Operate(result, inputProcessor.orStrings, invertedIndex);
            result = new SubtractSetOperator().Operate(result, inputProcessor.subtractStrings, invertedIndex);
            return result.ToList().OrderBy(i => i).ToList();
        }
    }
}