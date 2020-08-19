using System;
using System.Collections.Generic;
using System.Text;
using Nest;

namespace Learning
{
    static class ElasticClientFactory
    {
        private static IElasticClient client = CreateBaseClient();
        private const string uriPath = "http://localhost:9200/";

        private static IElasticClient CreateBaseClient()
        {
            var uri = new Uri(uriPath);
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
