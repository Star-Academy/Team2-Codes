using System;
using System.Collections.Generic;
using System.Text;
using InvertedIndex.Models;
using InvertedIndex.Utility.InputProcessor;
using Nest;

namespace InvertedIndex.QueryProcessor
{
    class ElasticQueryProcessor : IQueryProccesor
    {
        public IInputProcessor InputProcessorProvider { get; set; }

        public ElasticQueryProcessor()
        {
            InputProcessorProvider = new InputProcessor();
        }

        public List<string> PerformSearch(string input, IElasticClient client, string indexName)
        {
            InputProcessorProvider.ProcessInput(input);
            var andStrings = string.Join(" ", InputProcessorProvider.AndStrings);
            var orStrings = string.Join(" ", InputProcessorProvider.OrStrings);
            var subtractStrings = string.Join(" ", InputProcessorProvider.SubtractStrings);

            QueryContainer query = new BoolQuery
            {
                Must = new List<QueryContainer>
                {
                    new MatchQuery
                    {
                        Field = "content",
                        Query = andStrings
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
                        Query = orStrings
                    }
                }
            };
            var response = client.Search<Document>(s => s
                .Index(indexName)
                .Query(q => query).Take(10));
            // Console.WriteLine(myStr);

            return InputProcessorProvider.AndStrings;
        }
    }
}