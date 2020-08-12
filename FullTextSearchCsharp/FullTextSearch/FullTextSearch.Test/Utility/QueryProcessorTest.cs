using FullTextSearch.Model;
using FullTextSearch.Utility;
using FullTextSearchCsharp.FullTextSearch.FullTextSearch.Utility;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace FullTextSearch.Test.Utility{
    public class QueryProcessorTest
    {
        private const string Input = "hello -world +hi";
        private Dictionary<string, ISet<string>> indexMap;
        private InvertedIndex invertedIndex;
        private InputProcessor inputProcessor;
        private QueryProcessor queryProcessor;

        public QueryProcessorTest()
        {
            indexMap = new Dictionary<string, ISet<string>>();
            CreateSampleMap();
            invertedIndex = MockInvertedIndex();
            inputProcessor = MockInputProcessor();
            queryProcessor = new QueryProcessor(invertedIndex, inputProcessor);
        }

        private void CreateSampleMap()
        {
            var helloIndex = new HashSet<string> { "1", "2", "3", "4" };
            var worldIndex = new HashSet<string> { "2", "3" };
            var hiIndex = new HashSet<string> { "2", "4", "5" };

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

        private InputProcessor MockInputProcessor()
        {
            var processor = new Mock<InputProcessor>();
            processor
                .Setup(p => p.ProcessInput(It.IsAny<string>()))
                .Callback(() => {
                    processor.SetupAllProperties();
                    processor.Object.andStrings = new List<string> { "hello" };
                    processor.Object.orStrings = new List<string> { "hi" };
                    processor.Object.subtractStrings = new List<string> { "world" };
                });
            return processor.Object;
        }

        [Fact]
        public void PerformSearchTest()
        {
            var expectedAns = new List<string> { "1", "4", "5" };
            var actualAns = queryProcessor.PerformSearch(Input);

            Assert.Equal(expectedAns, actualAns);
        }
    }
}