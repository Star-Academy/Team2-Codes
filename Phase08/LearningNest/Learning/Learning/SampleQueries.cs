using System.Collections.Generic;
using Elasticsearch.Net;
using Learning.Model;
using Nest;

namespace Learning
{
    public class SampleQueries
    {
        public static IElasticsearchResponse BoolQuerySample1(IElasticClient client, string indexName)
        {
            QueryContainer query = new BoolQuery
            {
                Must = new List<QueryContainer>
                {
                    new MatchQuery
                    {
                        Field = "about",
                        Query = "Labore"
                    }
                }
            };
            var response = client.Search<Person>(s => s
                .Index(indexName)
                .Query(q => query));
            return response;
        }

        public static IElasticsearchResponse MatchQueryWithFuzzinessSample(IElasticClient client, string indexName)
        {
            QueryContainer query = new MatchQuery()
            {
                Field = "name",
                Query = "Syke",
                Fuzziness = Fuzziness.AutoLength(0, 2)
            };

            var response = client.Search<Person>(s => s
                .Index(indexName)
                .Query(q => query));
            return response;
        }
    }

    
}