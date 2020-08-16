using System.Collections.Generic;
using FullTextSearch.SetOperators;
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
            var initial = IndexMap["hello"];
            var result =
                new AndSetOperator().Operate(initial, new List<string> { "hi", "world" }, Indexes);
            Check.That(result).IsEquivalentTo("2");
        }
        [Fact]
        public void TestFullFunctionalityOfAndOnInvertedIndexWithNullQueryList()
        {
            var initial = IndexMap["hello"];
            var result =
                new AndSetOperator().Operate(initial, null, Indexes);
            Check.That(result).IsEquivalentTo("1","2","3","4");
        }
    }
}