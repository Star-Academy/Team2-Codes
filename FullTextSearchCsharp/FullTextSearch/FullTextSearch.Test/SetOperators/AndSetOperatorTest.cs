using System;
using System.Collections.Generic;
using System.IO;
using FullTextSearch.Model;
using FullTextSearch.SetOperators;
using FullTextSearch.Utility;
using Moq;
using NFluent;
using Xunit;

namespace FullTextSearch.Test.SetOperators
{
    public class AndSetOperatorTest : SetOperatorTest
    {
        [Fact]
        public void SimpleAndFunctionalityTest()
        {
            ISet<string> result = new HashSet<string> { "a", "b", "c" };
            ISet<string> subMask = new HashSet<string> { "a", "b" };
            new AndSetOperator().SpecificOperation(result, subMask);
            Check.That(result).IsEquivalentTo("a","b");
        }

        [Fact]
        public void TestFullFunctionalityOfAndOnInvertedIndex()
        {
            ISet<string> initial = IndexMap["hello"];
            ISet<string> result =
                new AndSetOperator().Operate(initial, new List<string> { "hi", "world" }, Indexes);
            Check.That(result).IsEquivalentTo("2");
        }
    }
}