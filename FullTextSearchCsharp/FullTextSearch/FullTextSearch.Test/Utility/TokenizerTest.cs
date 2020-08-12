using System;
using System.IO;
using FullTextSearch.Utility;
using NFluent;
using Xunit;

namespace FullTextSearch.Test.Utility
{
    public class TokenizerTest
    {
        [Fact]
        public void TokenizeContentTest()
        {
            string text = "hello world, new, amir. javad (Hi)";
            var tokenizer = new Tokenizer();
            var tokenized = tokenizer.TokenizeContent(text);
            Check.That(tokenized).ContainsExactly("hello", "world", "new", "amir", "javad", "Hi");
        }
    }
}