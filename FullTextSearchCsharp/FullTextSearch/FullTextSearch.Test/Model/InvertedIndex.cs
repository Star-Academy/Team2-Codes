using System.Collections.Generic;
using Xunit;
using FullTextSearch.Model;
using NFluent;
using Moq;


namespace FullTextSearch.Test.Model
{
    public class InvertedIndexTest
    {
        private InvertedIndex InvertedIndex { get; }

        public InvertedIndexTest()
        {
            InvertedIndex = new InvertedIndex();
        }

        public List<Document> GetTestDocuments()
        {
            var doc1 = new Mock<Document>();
            doc1.SetupAllProperties();
            doc1.Object.TokenizedWords = new HashSet<string> {"Hello", "World"};
            doc1.Object.Id = "1";

            var doc2 = new Mock<Document>();
            doc2.SetupAllProperties();
            doc2.Object.TokenizedWords = new HashSet<string> { "Hello", "Jahan" };
            doc2.Object.Id = "2";
            
            var doc3 = new Mock<Document>();
            doc3.SetupAllProperties();
            doc3.Object.TokenizedWords = new HashSet<string> {"Amir", "Javad"};
            doc3.Object.Id = "3";
            
            return new List<Document> {doc1.Object, doc2.Object, doc3.Object};
        }

        [Fact]
        public void AddMultipleDocuments()
        {
            var documents = GetTestDocuments();
            InvertedIndex.AddWordsOfMultipleDocuments(documents);
            Check.That(InvertedIndex.Indexes.Keys).Contains("Hello", "Javad" , "Amir"  , "Jahan" , "World");
            Check.That(InvertedIndex.Indexes["Hello"]).Contains("1","2");
            Check.That(InvertedIndex.Indexes["Amir"]).Contains("3");
        }


        [Fact]
        public void AddAllWordsOfDocument()
        {
            var words = new List<string> {"Ali", "Amir", "Javad"};
            InvertedIndex.AddAllWordsOfDocument(words, "1");
            Check.That(InvertedIndex.Indexes.Keys).Contains("Ali", "Javad");
            Check.That(InvertedIndex.Indexes["Javad"]).Contains("1");
        }

        [Fact]
        public void AddAllWordsOfDocumentThatDoesNotContain()
        {
            var words = new List<string> {"Ali", "Amir", "Javad"};
            InvertedIndex.AddAllWordsOfDocument(words, "1");
            Check.That(InvertedIndex.Indexes.Keys).Not.Contains("Ali", "Mohammad");
        }


        [Fact]
        public void AddAllWordsOfDocumentWithWrongId()
        {
            var words = new List<string> {"Ali", "Amir", "Javad"};
            InvertedIndex.AddAllWordsOfDocument(words, "1");
            Check.That(InvertedIndex.Indexes["Javad"]).Not.Contains("2");
        }


        [Fact]
        public void AddWordTestThatExistWithRightId()
        {
            InvertedIndex.AddWord("Hello", "1");
            Check.That(InvertedIndex.Indexes.Keys).Contains("Hello");
            Check.That(InvertedIndex.Indexes["Hello"]).Contains("1");
        }

        [Fact]
        public void AddWordTestThatExistWithWrongId()
        {
            InvertedIndex.AddWord("Hello", "1");
            Check.That(InvertedIndex.Indexes.Keys).Contains("Hello");
            Check.That(InvertedIndex.Indexes["Hello"]).Not.Contains("2");
        }

        [Fact]
        public void AddWordTestThatDoesNotExist()
        {
            InvertedIndex.AddWord("Hello", "1");
            Check.That(InvertedIndex.Indexes.Keys).Not.Contains("Salam");
        }
    }
}