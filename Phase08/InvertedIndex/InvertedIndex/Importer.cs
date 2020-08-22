using System.Collections.Generic;
using Elasticsearch.Net;
using Nest;

namespace InvertedIndex
{
    public class Importer<T> where T : class
    {
        private readonly IElasticClient client;

        public Importer()
        {
            client = ElasticClientFactory.CreateElasticClient();
        }

        public IElasticsearchResponse SendBulk(IEnumerable<T> entities, string indexName)
        {
            var bulk = MakeBulk(entities, indexName);
            var response = client.Bulk(bulk);
            return response;
        }

        public BulkDescriptor MakeBulk(IEnumerable<T> entities, string indexName)
        {
            var bulkDescriptor = new BulkDescriptor();
            foreach (var entity in entities)
            {
                bulkDescriptor.Index<T>(s => s.Index(indexName).Document(entity));
            }

            return bulkDescriptor;
        }

    }
}