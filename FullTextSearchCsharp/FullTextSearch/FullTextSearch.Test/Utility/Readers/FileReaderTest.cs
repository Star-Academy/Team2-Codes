using FullTextSearch.Utility.Readers;
using NFluent;
using Xunit;

namespace FullTextSearch.Test.Utility.Readers
{
    public class FileReaderTest
    {
        private FileReader TestFileReader { get; }

        public FileReaderTest()
        {
            TestFileReader = new FileReader(@"../../../../resources\\SmallDatabase");
        }

        [Fact]
        public void ListOfAllDocumentsTest()
        {
            TestFileReader.ListAllFilesInFolder();
            Check.That(TestFileReader.AllFilesInFolder).IsEquivalentTo("1.txt", "2.txt", "3.txt");
        }

        [Fact]

        public void GetDocuments()
        {
            var documents = TestFileReader.GetDocuments();
            var doc1 = documents[0];
            var doc2 = documents[1];
            var doc3 = documents[2];
            
            Assert.Equal("1.txt" , doc1.Id);
            Assert.Equal("2.txt" , doc2.Id);
            Assert.Equal("3.txt" , doc3.Id);
            Assert.Equal("hello world" , doc1.Content);
            Assert.Equal("hello jahan" , doc2.Content);
            Assert.Equal("amir javad" , doc3.Content);
        }

        [Fact]
        public void ReadOneFile()
        {
            var text = TestFileReader.ReadOneFile("1.txt");
            const string expected = "hello world";
            Assert.Equal(expected, text);
        }
    }
}