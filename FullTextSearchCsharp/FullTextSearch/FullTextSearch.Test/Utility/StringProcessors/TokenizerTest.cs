using System.Collections.Generic;
using FullTextSearch.Model;
using FullTextSearch.Utility.StringProcessors;
using NFluent;
using Xunit;

namespace FullTextSearch.Test.Utility.StringProcessors
{
    public class TokenizerTest
    {
        private readonly Tokenizer tokenizer;

        public TokenizerTest()
        {
            tokenizer = new Tokenizer();
        }

        [Fact]
        public void TokenizeContentTest()
        {
            const string text = "hello world, new, amir. javad (Hi)";
            var tokenized = tokenizer.TokenizeContent(text);
            Check.That(tokenized).IsEquivalentTo("hello", "world", "new", "amir", "javad", "Hi");
        }

        [Fact]
        public void TokenizeAllDocumentsTest()
        {
            var documents = CreateSampleDocs();
            tokenizer.TokenizeAllDocuments(documents);
            var expectedWords = CreateExpectedWords();

            Assert.Equal(expectedWords[0], documents[0].TokenizedWords);
            Assert.Equal(expectedWords[1], documents[1].TokenizedWords);
            Assert.Equal(expectedWords[2], documents[2].TokenizedWords);
        }

        private List<Document> CreateSampleDocs()
        {
            Document doc1 = new Document { Id = "1", Content = "hello, world" };
            Document doc2 = new Document { Id = "2", Content = "salam,', jahanian" };
            Document doc3 = new Document { Id = "3", Content = "amir,) javad(;" };
            return new List<Document> { doc1, doc2, doc3 };
        }

        private List<ISet<string>> CreateExpectedWords()
        {
            var doc1Words = new HashSet<string> { "hello", "world" };
            var doc2Words = new HashSet<string> { "salam", "jahanian" };
            var doc3Words = new HashSet<string> { "amir", "javad" };
            return new List<ISet<string>> { doc1Words, doc2Words, doc3Words };
        }
    }
}