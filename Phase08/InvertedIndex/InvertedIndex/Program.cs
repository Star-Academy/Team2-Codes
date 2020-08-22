using System;
using System.Collections.Generic;
using Elasticsearch.Net;
using InvertedIndex.Models;
using InvertedIndex.QueryProcessor;
using InvertedIndex.Utility.Readers;
using InvertedIndex.View;
using Nest;
using Validator;

namespace InvertedIndex
{
    public class Program
    {
        private static readonly string IndexName = "document_test";
        private static readonly string ResourceAddress = "../../../../resources/EnglishData";
        private static readonly ConsolePrinter ConsolePrinterProvider = new ConsolePrinter();

        public static void Main(string[] args)
        {
            InitializeIndex();
            while (true)
            {
                var inputStr = Console.ReadLine();
                var elastic =
                    new ElasticQueryProcessor(ElasticClientFactory.CreateElasticClient(), IndexName);
                try
                {
                    var result = elastic.PerformSearch(inputStr);
                    ConsolePrinterProvider.ShowResult(result);
                }
                catch (Exception e)
                {
                    ConsolePrinterProvider.ShowException(e);
                }
            }
        }

        public static void InitializeIndex()
        {
            var indexMaker = new IndexMaker();
            var response = indexMaker.MakeIndex(IndexName);
            var ValidationResult = ElasticValidator.ValidateElasticResponse(response);
            if (ValidationResult.IsValid == false)
            {
                ConsolePrinterProvider.ShowException(ValidationResult.ElasticException);
            }
            else
            {
                ConsolePrinterProvider.ShowMessage("Index Made Successfully");
            }
        }
    }
}