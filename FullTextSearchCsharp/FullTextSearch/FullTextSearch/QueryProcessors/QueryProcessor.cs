using System.Collections.Generic;
using System.Linq;
using FullTextSearch.Model;
using FullTextSearch.SetOperators;
using FullTextSearch.Utility.StringProcessors;
using FullTextSearch.Utility.StringProcessors.InputProcessors;

namespace FullTextSearch.QueryProcessors
{
    public class QueryProcessor : IQueryProcessor
    {
        public InvertedIndex InvertedIndexProvider { get; set; }
        public IInputProcessor InputProcessorProvider { get; set; }

        /*We have two constructors because we are developing a library
        users can simply pass documents to query processor
        Or if they made the inverted Index and inputProcessor themselves
        And just want to use simple searching functionality
        they can just pass them without bothering with documents. */
        public QueryProcessor(List<Document> documents)
        {
            new Tokenizer().TokenizeAllDocuments(documents);
            InputProcessorProvider = new InputProcessor();
            InvertedIndexProvider = new InvertedIndex();
            InvertedIndexProvider.AddWordsOfMultipleDocuments(documents);
        }

        public QueryProcessor(InvertedIndex invertedIndex,IInputProcessor inputProcessor )
        {

            InputProcessorProvider = inputProcessor;
            InvertedIndexProvider = invertedIndex;
        }

        public List<string> PerformSearch(string input)
        {
            InputProcessorProvider.ProcessInput(input);
            var result = PrepareResultSet();
            return DoSearchStrategies(result);
        }

        private ISet<string> PrepareResultSet()
        {
            /*This method is used so if we have any AND string, it must be assigned to result set.
              Because AND has higher precedence and operating it on empty non initialized don't give us appropriate results.  */
            ISet<string> result = new HashSet<string>(); 
            if (InputProcessorProvider.AndStrings.Any())
            {
                var firstWordInAndStrings = InputProcessorProvider.AndStrings[0];
                result.UnionWith(InvertedIndexProvider.Indexes[firstWordInAndStrings]);
            }
            return result;
        }

        private List<string> DoSearchStrategies(ISet<string> result)
        {
            // Precedence: AND -> OR -> SUBTRACT
            result = new AndSetOperator().Operate(result, InputProcessorProvider.AndStrings, InvertedIndexProvider);
            result = new OrSetOperator().Operate(result, InputProcessorProvider.OrStrings, InvertedIndexProvider);
            result = new SubtractSetOperator().Operate(result, InputProcessorProvider.SubtractStrings, InvertedIndexProvider);
            return result.ToList().OrderBy(i => i).ToList();
        }
    }
}