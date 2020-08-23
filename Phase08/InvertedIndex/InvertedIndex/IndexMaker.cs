using Elasticsearch.Net;
using InvertedIndex.Mapping;
using InvertedIndex.Models;
using Nest;

namespace InvertedIndex
{
    class IndexMaker
    {
        private readonly IElasticClient client;

        public IndexMaker()
        {
            client = ElasticClientFactory.CreateElasticClient();
        }

        public IResponse MakeIndex(string indexName)
        {
            var response = client.Indices.Create(indexName, s =>
                s.Settings(ConfigureSettings).Map<Document>(ConfigureMapping));
            return response;
        }

        private IPromise<IIndexSettings> ConfigureSettings(IndexSettingsDescriptor indexSettingsDescriptor)
        {
            return indexSettingsDescriptor.Setting("max_ngram_diff", 10);
        }


        private ITypeMapping ConfigureMapping(TypeMappingDescriptor<Document> typeMappingDescriptor)
        {
            return typeMappingDescriptor.Properties(pr => pr
                    .AddIdMapping()
                    .AddContentMapping());
        }
    }
}