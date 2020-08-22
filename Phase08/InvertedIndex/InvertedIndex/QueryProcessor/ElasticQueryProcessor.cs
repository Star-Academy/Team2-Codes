using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using InvertedIndex.Models;
using InvertedIndex.Utility.InputProcessor;
using Nest;
using Validator;

namespace InvertedIndex.QueryProcessor
{
    class ElasticQueryProcessor : IQueryProcessor
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


        public IEnumerable<string> PerformSearch(string input , int numberToTake = 10)
        {
            InputProcessorProvider.ProcessInput(input);
            QueryContainer query = MakeQuery(InputProcessorProvider.AndStrings, InputProcessorProvider.OrStrings,
                InputProcessorProvider.SubtractStrings);

            var response = Client.Search<Document>(s => s
                .Index(IndexName)
                .Query(q => query).Take(numberToTake));

            var responseValidationResult = ElasticValidator.ValidateElasticResponse(response);
            if (responseValidationResult.IsValid)
            {
                var ids = ElasticResponseToEnumerable(response);
                return ids;
            }
            throw responseValidationResult.ElasticException;
        }

        private IEnumerable<string> ElasticResponseToEnumerable(ISearchResponse<Document> response)
        {
            var ids = from doc in response.Documents select doc.Id;
            return ids.ToList();
        }

        private QueryContainer MakeQuery(IEnumerable<string> andList, IEnumerable<string> orList,
            IEnumerable<string> subtractList)
        {
            var andStrings = string.Join(" ", andList);
            var orStrings = string.Join(" ", orList);
            var subtractStrings = string.Join(" ", subtractList);
            return new BoolQuery
            {
                Must = new List<QueryContainer>
                {
                    new MatchQuery
                    {
                        Field = "content",
                        Query = andStrings,
                        Operator = Operator.And,
                    }
                },
                MustNot = new List<QueryContainer>
                {
                    new MatchQuery()
                    {
                        Field = "content",
                        Query = subtractStrings
                    }
                },
                Should = new List<QueryContainer>
                {
                    new MatchQuery()
                    {
                        Field = "content",
                        Query = orStrings,
                    }
                }
            };
        }
    }
}