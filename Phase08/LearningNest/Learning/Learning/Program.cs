using System;
using Nest;
using System.Text.Json;


namespace Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = ElasticClientFactory.CreateElasticClient();
            var response = client.Ping();
        }
    }
}
