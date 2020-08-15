using System.Collections.Generic;
using System.Linq;

namespace FullTextSearch.Model
{
    public class InvertedIndex
    {
        public IDictionary<string, ISet<string>> Indexes { get; set; } = new Dictionary<string, ISet<string>>();

        public void AddAllWordsOfDocument(List<string> words, string id)
        {
            if (words.Any())
            {
                foreach (var word in words)
                {
                    AddWord(word, id);
                }
            }
        }

        public void AddWordsOfMultipleDocuments(List<Document> documents)
        {
            if (documents.Any())
            {
                foreach (var document in documents)
                {
                    AddAllWordsOfDocument(document.TokenizedWords.ToList(), document.Id);
                }
            }
        }

        public void AddWord(string word, string id)
        {
            if (Indexes.TryGetValue(word, out var set))
            {
                set.Add(id);
            }
            else
            {
                Indexes.Add(word, new HashSet<string>());
                Indexes[word].Add(id);
            }
        }
    }
}