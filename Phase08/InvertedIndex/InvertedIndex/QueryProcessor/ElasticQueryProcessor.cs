using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using InvertedIndex.Models;
using InvertedIndex.Utility.InputProcessor;
using Nest;
using Validator;

namespace InvertedIndex.QueryProcessor
{
    public class ElasticQueryProcessor : IQueryProcessor
    {
        public IInputProcessor InputProcessorProvider { get; set; }
        public IElasticClient Client { get; }
        public string IndexName { get; set; }

        public ElasticQueryProcessor([NotNull] IElasticClient client, string indexName)
        {
            InputProcessorProvider = new InputProcessor();
            Client = client;
            IndexName = indexName;
        }


        public IEnumerable<string> PerformSearch(string input, int numberToTake = 10, int pageNumber = 1)
        {
            InputProcessorProvider.ProcessInput(input);
            var query = MakeSearchQuery(InputProcessorProvider.AndStrings, InputProcessorProvider.OrStrings,
                InputProcessorProvider.SubtractStrings);

            var response = Client.Search<Document>(s => s
                .Index(IndexName)
                .Query(q => query).From((pageNumber - 1) * numberToTake).Size(numberToTake));

            var responseValidationResult = ElasticValidator.ValidateElasticResponse(response);
            if (responseValidationResult.IsValid)
            {
                var ids = ElasticResponseToEnumerable(response);
                return ids;
            }

            throw responseValidationResult.ElasticException;
        }

        public Document GetDocumentByID(string id)
        {
            var query = new TermQuery()
            {
                Field = "id",
                Value = id
            };
            var response = Client.Search<Document>(s => s.Index(IndexName).Query(q => query));
            var responseValidationResult = ElasticValidator.ValidateElasticResponse(response);
            if (responseValidationResult.IsValid)
            {
                if (response.Documents != null && response.Documents.Count != 0)
                {
                    return response.Documents.First();
                }

                return Document.Null;
            }

            throw responseValidationResult.ElasticException;
        }

        private IEnumerable<string> ElasticResponseToEnumerable(ISearchResponse<Document> response)
        {
            var ids = from doc in response.Documents select doc.Id;
            return ids.ToList();
        }

        private QueryContainer MakeSearchQuery(IEnumerable<string> andList, IEnumerable<string> orList,
            IEnumerable<string> subtractList)
        {
            var andStrings = string.Join(" ", andList);
            var orStrings = string.Join(" ", orList);
            var subtractStrings = string.Join(" ", subtractList);
            var elasticQuery = new BoolQuery
            {
                MustNot = new List<QueryContainer>(),
                Should = new List<QueryContainer>()
            };
            return elasticQuery.AddMinusWords(subtractStrings)
                .AddPlusWords(orStrings)
                .AddNonSignedWords(andStrings);
        }
    }
}