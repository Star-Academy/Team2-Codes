using System;
using Elasticsearch.Net;
using InvertedIndex.Models;
using InvertedIndex.QueryProcessor;
using InvertedIndex.Utility.Readers;
using InvertedIndex.View;
using Nest;
using Validator;

namespace InvertedIndex
{
    public class Controller
    {
        private readonly string indexName;
        private readonly string resourceAddress;
        private readonly IQueryProcessor queryProcessor;
        private static readonly IPrinter ConsolePrinterProvider = new ConsolePrinter();

        public Controller(string resourceAddress, string indexName)
        {
            this.indexName = indexName;
            this.resourceAddress = resourceAddress;
            queryProcessor = new ElasticQueryProcessor(ElasticClientFactory.CreateElasticClient(), indexName);
        }


        public void LoadAndSendDocuments()
        {
            FileReader fileReader = new FileReader(resourceAddress);
            var documents = fileReader.GetDocuments();
            var importer = new Importer<Document>();
            var response = importer.SendBulk(documents, indexName);
            ShowValidationResult(response, "Bulk Send Successful");
        }


        public void InitializeIndex()
        {
            var indexMaker = new IndexMaker();
            var response = indexMaker.MakeIndex(indexName);
            ShowValidationResult(response, "Index Made Successfully");
        }

        public static void ShowValidationResult(IResponse response, string successMessage)
        {
            var validationResult = ElasticValidator.ValidateElasticResponse(response);
            if (!validationResult.IsValid)
            {
                ConsolePrinterProvider.ShowException(validationResult.ElasticException,validationResult.HttpStatusCode);
            }
            else
            {
                ConsolePrinterProvider.ShowMessage(successMessage);
            }
        }

        public void Search(string inputString)
        {
            try
            {
                var result = queryProcessor.PerformSearch(inputString);
                ConsolePrinterProvider.ShowResult(result);
            }
            catch (Exception e)
            {
                ConsolePrinterProvider.ShowException(e);
            }
        }
    }
}