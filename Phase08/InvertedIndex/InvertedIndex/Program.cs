using System;
using System.Collections.Generic;
using Elasticsearch.Net;
using InvertedIndex.Models;
using InvertedIndex.Utility.Readers;
using Validator;

namespace InvertedIndex
{
    public class Program
    {
        private static readonly string IndexName = "document_test";
        private static readonly string ResourceAddress = "../../../../resources/EnglishData";
        private static ElasticValidator ElasticValidatorProvider = new ElasticValidator();
        public static void Main(string[] args)
        {

            // var response = InitializeIndex();
            // var validationResult = ElasticValidatorProvider.ValidateElasticResponse(response);
            // if (validationResult.IsValid)
            // {
            //     Console.WriteLine("Index Created Successfully");
            // }
            

            var fileReader = new FileReader(ResourceAddress);
            var documents = fileReader.GetDocuments();

            var elasticsearchResponse = new Importer<Document>().SendBulk(documents,IndexName);
        }

        public static IElasticsearchResponse InitializeIndex()
        {
            var indexMaker = new IndexMaker();
            var response = indexMaker.MakeIndex(IndexName);
            return response;
        }
    }
}
