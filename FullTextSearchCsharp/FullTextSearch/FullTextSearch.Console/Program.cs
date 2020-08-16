using System;
using System.Collections.Generic;
using FullTextSearch.QueryProcessors;
using FullTextSearch.Utility.Readers;

namespace FullTextSearch.Console
{
    class Program
    {
        private const string address = "..\\..\\..\\..\\resources\\EnglishData";

        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader(address);
            var documents = fileReader.GetDocuments();
            QueryProcessor queryProcessor = new QueryProcessor(documents);

            while (true)
            {
                string query = System.Console.ReadLine();
                var answerIds = queryProcessor.PerformSearch(query);
                PrintFormatted(answerIds);
            }
        }

        static void PrintFormatted(IEnumerable<string> idList)
        {
            foreach (var id in idList)
            {
                System.Console.Write($"{id} ");
            }

            System.Console.WriteLine();
        }
    }
}