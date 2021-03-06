﻿using FullTextSearch.QueryProcessors;
using FullTextSearch.Utility.Printers;
using FullTextSearch.Utility.Readers;

namespace FullTextSearch.Console
{
    static class Program
    {
        private const string address = "../../../../resources/EnglishData";

        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader(address);
            var documents = fileReader.GetDocuments();
            QueryProcessor queryProcessor = new QueryProcessor(documents);
            ConsolePrinter consolePrinter = new ConsolePrinter();
            while (true)
            {
                string query = System.Console.ReadLine();
                var answerIds = queryProcessor.PerformSearch(query);
                consolePrinter.ShowStrings(answerIds);
            }
        }
    }
}