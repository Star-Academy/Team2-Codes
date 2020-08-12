using System.Collections.Generic;
using FullTextSearch.Utility;
using Xunit;
using System.Linq;

namespace FullTextSearch.Test.Utility
{
    public class InputProcessorTest
    {
        private const string Input = "hello +world -salam +jahan amir -javad";
        private InputProcessor processor;

        public InputProcessorTest()
        {
            processor = new InputProcessor();
        }

        [Fact]
        public void ProcessInputTest()
        {
            processor.ProcessInput(Input);

            Assert.Equal(new List<string> { "hello", "amir" }, processor.andStrings);
            Assert.Equal(new List<string> { "world", "jahan" }, processor.orStrings);
            Assert.Equal(new List<string> { "salam", "javad" }, processor.subtractStrings);
        }

        [Fact]
        public void ExtractWordsTest()
        {
            var expectedWords = new List<string> { "world", "jahan" };
            var actualWords = processor.ExtractWords(Input, "\\+(\\w+)");

            Assert.Equal(expectedWords, actualWords);
        }
    }
}