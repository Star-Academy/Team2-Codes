using System.Collections.Generic;
using Elasticsearch.Net;
using Learning.Model;
using Nest;

namespace Learning
{
    public class SampleQueries
    {
        private readonly IElasticClient client;
        private readonly string indexName;

        public SampleQueries(IElasticClient client, string indexName)
        {
            this.client = client;
            this.indexName = indexName;
        }

        public IElasticsearchResponse BoolQuerySample1()
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

        public IElasticsearchResponse MatchQueryWithFuzzinessSample()
        {
            QueryContainer query = new MatchQuery
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

        public IElasticsearchResponse FuzzyQuerySample()
        {
            QueryContainer query = new FuzzyQuery
            {
                Field = "name",
                Value = "Syke",
                Fuzziness = Fuzziness.AutoLength(0, 2)
            };

            var response = client.Search<Person>(s => s
                .Index(indexName)
                .Query(q => query));
            return response;
        }

        public IElasticsearchResponse TermQuerySample()
        {
            QueryContainer query = new TermQuery
            {
                Field = "email.email",
                Value = "deannegarrison@recognia.com"
            };
            var response = client.Search<Person>(s => s
                .Index(indexName)
                .Query(q => query));
            return response;
        }

        public IElasticsearchResponse TermsQuerySample()
        {
            QueryContainer query = new TermsQuery
            {
                Field = "email.email",
                Terms = new[]
                {
                    "deannegarrison@recognia.com",
                    "huberbeard@freakin.com"
                }
            };
            var response = client.Search<Person>(s => s
                .Index(indexName)
                .Query(q => query));
            return response;
        }

        public IElasticsearchResponse GeoDistanceSampleQuery()
        {
            QueryContainer query = new GeoDistanceQuery
            {
                Field = "location",
                DistanceType = GeoDistanceType.Arc,
                Location = new GeoLocation(-4.5, 142),
                Distance = "200km",
                ValidationMethod = GeoValidationMethod.IgnoreMalformed
            };
            var response = client.Search<Person>(s => s
                .Index(indexName)
                .Query(q => query));
            return response;
        }

        public IElasticsearchResponse DateRangeSampleQuery()
        {
            QueryContainer query = new DateRangeQuery
            {
                Field = "registrationDate",
                GreaterThan = DateMath.FromString("2020-07-05T08:29:10"),
                LessThanOrEqualTo = DateMath.Now
            };
            var response = client.Search<Person>(s => s
                .Index(indexName)
                .Query(q => query));
            return response;
        }

        public IElasticsearchResponse TermsAggregation()
        {
            var response = client.Search<Person>(s => s
                .Index(indexName).Aggregations(a => a
                    .Terms("unique_colors", d => d
                        .Field("eyeColor.keyword"))));
            return response;
        }

        public IElasticsearchResponse MultiMatchQuerySample()
        {
            var response = client.Search<Person>(s => s
                .Index(indexName)
                .Query(q => q.MultiMatch(m =>
                    m.Fields(f => f
                            .Field("name")
                            .Field("address"))
                        .Query("marshall"))));
            return response;
        }
    }
}