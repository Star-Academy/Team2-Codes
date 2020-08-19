using Learning.Model;
using Nest;

namespace Learning
{
    class IndexMaker
    {
        private IElasticClient client;

        public IndexMaker()
        {
            client = ElasticClientFactory.CreateElasticClient();
        }

        public void MakeIndex(string indexName)
        {
            var response = client.Indices.Create(indexName, s =>
                s.Settings(ConfigureSettings).Map<Person>(ConfigureMapping));
        }

        private IPromise<IIndexSettings> ConfigureSettings(IndexSettingsDescriptor indexSettingsDescriptor)
        {
            return indexSettingsDescriptor.Setting("max_ngram_diff", 10).Analysis(ConfigureAnalysis);
        }


        private ITypeMapping ConfigureMapping(TypeMappingDescriptor<Person> typeMappingDescriptor)
        {
            return typeMappingDescriptor.Properties(pr => pr);
        }


        private IAnalysis ConfigureAnalysis(AnalysisDescriptor analysisDescriptor)
        {
            return analysisDescriptor.TokenFilters(AnalyzerConfigurator.MakeTokenFilters)
                .Tokenizers(AnalyzerConfigurator.MakeTokenizers).Analyzers(AnalyzerConfigurator.MakeAnalyzer);
        }
    }
}