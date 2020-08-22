using System;

namespace InvertedIndex
{
    public static class Program
    {
        private static readonly string IndexName = "document_test";
        private static readonly string ResourceAddress = "../../../../resources/EnglishData";

        public static void Main(string[] args)
        {
            var controller = new Controller(ResourceAddress, IndexName);
            controller.InitializeIndex();
            //controller.LoadAndSendDocuments() //-> Should only be called once. each time it send all the documents to server
            while (true)
            {
                var inputStr = Console.ReadLine();
                controller.Search(inputStr);
            }
        }
    }
}