using System;
using Nest;

namespace InvertedIndex
{
    static class ElasticClientFactory
    {
        private static readonly IElasticClient client = CreateBaseClient();
        private const string UriPath = "http://localhost:9200/";

        private static IElasticClient CreateBaseClient()
        {
            var uri = new Uri(UriPath);
            var settings = new ConnectionSettings(uri);
            settings.EnableDebugMode();
            return new ElasticClient(settings);
        }

        public static IElasticClient CreateElasticClient()
        {
            return client;
        }
    }
}