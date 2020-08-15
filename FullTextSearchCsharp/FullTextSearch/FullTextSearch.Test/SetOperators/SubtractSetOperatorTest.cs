using System.Collections.Generic;
using FullTextSearch.SetOperators;
using NFluent;
using Xunit;


namespace FullTextSearch.Test.SetOperators
{
    public class SubtractSetOperatorTest : SetOperatorTest
    {
        [Fact]
        public void NotEmptyInitialSetCommonElementTest()
        {
            ISet<string> result = new HashSet<string> {"a", "b", "c"};
            ISet<string> subMask = new HashSet<string> {"a", "b"};

            new SubtractSetOperator().SpecificOperation(result, subMask);
            Check.That(result).IsEquivalentTo("c");
        }

        [Fact]
        public void NotEmptyInitialSetSubtractNothing()
        {
            ISet<string> result = new HashSet<string> {"a", "b", "c"};
            ISet<string> subMask = new HashSet<string>();

            new SubtractSetOperator().SpecificOperation(result, subMask);
            Check.That(result).IsEquivalentTo("a", "b", "c");
        }

        [Fact]
        public void NotEmptyInitialSetSubtractNotCommon()
        {
            ISet<string> result = new HashSet<string> {"a", "b", "c"};
            ISet<string> subMask = new HashSet<string> {"d", "e"};

            new SubtractSetOperator().SpecificOperation(result, subMask);
            Check.That(result).IsEquivalentTo("a", "b", "c");
        }

        [Fact]
        public void EmptyInitialSetTest()
        {
            ISet<string> result = new HashSet<string>();
            ISet<string> subMask = new HashSet<string> {"d", "e"};

            new SubtractSetOperator().SpecificOperation(result, subMask);
            Check.That(result).Not.IsEquivalentTo("d", "e");
        }

        [Fact]
        public void TestFullFunctionalityOfSubtractOnInvertedIndex()
        {
            var initial = IndexMap["hello"];
            var result =
                new SubtractSetOperator().Operate(initial, new List<string> {"hi", "world"}, Indexes);
            Check.That(result).IsEquivalentTo("1");
        }
    }
}