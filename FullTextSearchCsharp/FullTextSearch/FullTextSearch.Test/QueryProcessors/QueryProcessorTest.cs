using FullTextSearch.Model;
using FullTextSearch.Utility;
using Moq;
using Xunit;
using System.Collections.Generic;
using FullTextSearch.QueryProcessors;
using FullTextSearch.Utility.StringProcessors.InputProcessor;

namespace FullTextSearch.Test.Utility
{
    public class QueryProcessorTest
    {
        private const string Input = "hello -world +hi";
        private const string Input2 = "hello";
        private const string Input3 = "hello -may";
        private Dictionary<string, ISet<string>> indexMap;
        private InvertedIndex invertedIndex;
        private InputProcessor inputProcessor;
        private QueryProcessor queryProcessor;

        public void QueryProcessorTestInitializerForTwoParametersTest()
        {
            indexMap = new Dictionary<string, ISet<string>>();
            CreateSampleMap();
            invertedIndex = MockInvertedIndex();
            inputProcessor = MockInputProcessor();
            queryProcessor = new QueryProcessor(invertedIndex, inputProcessor);
        }

        private void CreateSampleMap()
        {
            var helloIndex = new HashSet<string> {"1", "2", "3", "4"};
            var worldIndex = new HashSet<string> {"2", "3"};
            var hiIndex = new HashSet<string> {"2", "4", "5"};

            indexMap.Add("hello", helloIndex);
            indexMap.Add("world", worldIndex);
            indexMap.Add("hi", hiIndex);
        }

        private InvertedIndex MockInvertedIndex()
        {
            var indexes = new Mock<InvertedIndex>();
            indexes.SetupAllProperties();
            indexes.Object.Indexes = indexMap;
            return indexes.Object;
        }

        public List<Document> GetTestDocuments()
        {
            var doc1 = new Mock<Document>();
            doc1.SetupAllProperties();
            doc1.Object.Content = "hello";
            doc1.Object.Id = "1.txt";

            var doc2 = new Mock<Document>();
            doc2.SetupAllProperties();
            doc2.Object.Content = "hello may";
            doc2.Object.Id = "2.txt";

            var doc3 = new Mock<Document>();
            doc3.SetupAllProperties();
            doc3.Object.Content = "hello world";
            doc3.Object.Id = "3.txt";

            var doc4 = new Mock<Document>();
            doc4.SetupAllProperties();
            doc4.Object.Content = "albnyvms world may";
            doc4.Object.Id = "4.txt";


            return new List<Document> {doc1.Object, doc2.Object, doc3.Object, doc4.Object};
        }


        private InputProcessor MockInputProcessor()
        {
            var processor = new Mock<InputProcessor>();
            processor
                .Setup(p => p.ProcessInput(It.IsAny<string>()))
                .Callback(() =>
                {
                    processor.SetupAllProperties();
                    processor.Object.AndStrings = new List<string> {"hello"};
                    processor.Object.OrStrings = new List<string> {"hi"};
                    processor.Object.SubtractStrings = new List<string> {"world"};
                });
            return processor.Object;
        }


        [Fact]
        public void PerformSearchTestWithOneParameterConstructorSimpleQuery()
        {
            var queryProcessor = new QueryProcessor(GetTestDocuments());
            var expectedAns = new List<string> {"1.txt", "2.txt", "3.txt"};
            var actualAns = queryProcessor.PerformSearch(Input2);
            Assert.Equal(expectedAns, actualAns);
        }

        [Fact]
        public void PerformSearchTestWithOneParameterConstructorAdvancedQuery()
        {
            var queryProcessor = new QueryProcessor(GetTestDocuments());
            var expectedAns = new List<string> { "1.txt", "3.txt" };
            var actualAns = queryProcessor.PerformSearch(Input3);
            Assert.Equal(expectedAns, actualAns);
        }




        [Fact]
        public void PerformSearchTestWithTwoParameterConstructor()
        {
            QueryProcessorTestInitializerForTwoParametersTest();
            var expectedAns = new List<string> {"1", "4", "5"};
            var actualAns = queryProcessor.PerformSearch(Input);

            Assert.Equal(expectedAns, actualAns);
        }
    }
}