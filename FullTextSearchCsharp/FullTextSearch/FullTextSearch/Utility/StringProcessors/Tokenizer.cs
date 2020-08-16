using System;
using System.Collections.Generic;
using System.Linq;
using FullTextSearch.Model;

namespace FullTextSearch.Utility.StringProcessors
{
    public class Tokenizer
    {
        private static readonly char[] separators =
            {' ', ',', '.', ';', ':', '-', '\'', '(', ')', '\"', '@', '[', ']', '>', '<', '\t', '\n', '\0'};

        public ISet<string> TokenizeContent(string content)
        {
            return content.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToHashSet();
        }

        public void TokenizeAllDocuments(List<Document> allDocuments)
        {
            allDocuments.ForEach(d => d.TokenizedWords = TokenizeContent(d.Content));
        }
    }
}