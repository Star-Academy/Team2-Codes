using System.Collections.Generic;
using FullTextSearch.Utility;
using Xunit;
using System.Linq;
using System.Text.RegularExpressions;

namespace FullTextSearch.Test.Utility
{
    public class InputProcessorTest
    {
        private readonly Regex actualWordRegex = new Regex("\\+(\\w+)");
        private const string Input = "hello +world -salam +jahan amir -javad";
        private readonly InputProcessor processor;

        public InputProcessorTest()
        {
            processor = new InputProcessor();
        }

        [Fact]
        public void ProcessInputTest()
        {
            processor.ProcessInput(Input);

            Assert.Equal(new List<string> { "hello", "amir" }, processor.AndStrings);
            Assert.Equal(new List<string> { "world", "jahan" }, processor.OrStrings);
            Assert.Equal(new List<string> { "salam", "javad" }, processor.SubtractStrings);
        }

        [Fact]
        public void ExtractWordsTest()
        {
            var expectedWords = new List<string> { "world", "jahan" };
            var actualWords = processor.ExtractWords(Input, actualWordRegex);

            Assert.Equal(expectedWords, actualWords);
        }
    }
}