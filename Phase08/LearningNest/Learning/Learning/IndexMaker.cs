using Elasticsearch.Net;
using Learning.AnalysisSettings;
using Learning.Mapping;
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

        public IElasticsearchResponse MakeIndex(string indexName)
        {
            var response = client.Indices.Create(indexName, s =>
                s.Settings(ConfigureSettings).Map<Person>(ConfigureMapping));
            return response;
        }

        private IPromise<IIndexSettings> ConfigureSettings(IndexSettingsDescriptor indexSettingsDescriptor)
        {
            return indexSettingsDescriptor.Setting("max_ngram_diff", 11).Analysis(ConfigureAnalysis);
        }


        private ITypeMapping ConfigureMapping(TypeMappingDescriptor<Person> typeMappingDescriptor)
        {
            return typeMappingDescriptor.Properties(pr =>
                pr.AddPersonAboutMapping()
                    .AddPersonAddressMapping()
                    .AddPersonAgeMapping()
                    .AddPersonCompanyMapping()
                    .AddPersonCompanyMapping()
                    .AddPersonEmailMapping()
                    .AddPersonEyeColorMapping()
                    .AddPersonGenderMapping()
                    .AddPersonLocationMapping()
                    .AddPersonNameMapping()
                    .AddPersonPhoneMapping()
                    .AddPersonRegistrationDateMapping());
        }


        private IAnalysis ConfigureAnalysis(AnalysisDescriptor analysisDescriptor)
        {
            return analysisDescriptor.TokenFilters(AnalyzerConfigurator.MakeTokenFilters)
                .Tokenizers(AnalyzerConfigurator.MakeTokenizers).Analyzers(AnalyzerConfigurator.MakeAnalyzer);
        }
    }
}