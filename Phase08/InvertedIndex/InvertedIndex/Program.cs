using System;

namespace InvertedIndex
{
    public static class Program
    {
        private const string IndexName = "document_test";
        private const string ResourceAddress = "../../../../resources/EnglishData";

        public static void Main(string[] args)
        {
            var controller = new Controller(ResourceAddress, IndexName);
            // controller.InitializeIndex(); // -> Should be called once. (calling it more times has no side-effect)
            // controller.LoadAndSendDocuments() //-> Must only be called once. each time it send all the documents to server
            while (true)
            {
                var inputStr = Console.ReadLine();
                controller.Search(inputStr,1000);
            }
        }
    }
}