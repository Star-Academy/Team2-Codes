using System.Collections.Generic;
using System.Linq;
using FullTextSearch.Model;
using FullTextSearch.SetOperators;

namespace FullTextSearch.Utility
{
    public class QueryProcessor
    {
        public InvertedIndex InvertedIndexProvider;
        public InputProcessor InputProcessorProvider;

        public QueryProcessor(InvertedIndex invertedIndexProvider, InputProcessor inputProcessorProvider)
        {
            this.InvertedIndexProvider = invertedIndexProvider;
            this.InputProcessorProvider = inputProcessorProvider;
        }

        public List<string> PerformSearch(string input)
        {
            InputProcessorProvider.ProcessInput(input);
            var result = PrepareResultSet();
            return DoSearchStrategies(result);
        }

        private ISet<string> PrepareResultSet()
        {
            ISet<string> result = new HashSet<string>(); 
            if (InputProcessorProvider.AndStrings.Any())
            {
                var firstWordInAndStrings = InputProcessorProvider.AndStrings[0];
                result.UnionWith(InvertedIndexProvider.Indexes[firstWordInAndStrings]);
            }
            return result;
        }

        public List<string> DoSearchStrategies(ISet<string> result)
        {
            result = new AndSetOperator().Operate(result, InputProcessorProvider.AndStrings, InvertedIndexProvider);
            result = new OrSetOperator().Operate(result, InputProcessorProvider.OrStrings, InvertedIndexProvider);
            result = new SubtractSetOperator().Operate(result, InputProcessorProvider.SubtractStrings, InvertedIndexProvider);
            return result.ToList().OrderBy(i => i).ToList();
        }
    }
}