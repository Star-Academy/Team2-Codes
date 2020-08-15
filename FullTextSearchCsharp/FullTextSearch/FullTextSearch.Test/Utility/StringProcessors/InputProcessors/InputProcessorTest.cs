using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;
using FullTextSearch.Utility.StringProcessors.InputProcessors;

namespace FullTextSearch.Test.Utility.StringProcessors.InputProcessors
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