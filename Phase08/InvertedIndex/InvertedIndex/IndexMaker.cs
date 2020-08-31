using InvertedIndex.Mapping;
using InvertedIndex.Models;
using Nest;

namespace InvertedIndex
{
    public class IndexMaker
    {
        private readonly IElasticClient client;
        private const int MaxNgramDiffValue = 10;
        private const string MaxNgramDiffElasticName = "max_ngram_diff";

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
            return indexSettingsDescriptor.Setting(MaxNgramDiffElasticName, MaxNgramDiffValue);
        }


        private ITypeMapping ConfigureMapping(TypeMappingDescriptor<Document> typeMappingDescriptor)
        {
            return typeMappingDescriptor.Properties(pr => pr
                    .AddIdMapping()
                    .AddContentMapping());
        }
    }
}