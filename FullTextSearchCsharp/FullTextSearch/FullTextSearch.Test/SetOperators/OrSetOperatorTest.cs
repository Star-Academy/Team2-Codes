using System;
using System.Collections.Generic;
using System.IO;
using FullTextSearch.SetOperators;
using FullTextSearch.Utility;
using NFluent;
using Xunit;


namespace FullTextSearch.Test.SetOperators
{
    public class OrSetOperatorTest : SetOperatorTest
    {

        [Fact]
        public void NotEmptyInitialSetCommonElementTest()
        {
            ISet<string> result = new HashSet<string> { "a", "b", "c" };
            ISet<string> subMask = new HashSet<string> {"a" , "b" };

            new OrSetOperator().SpecificOperation(result, subMask);
            Check.That(result).IsEquivalentTo("a", "b", "c");
        }


        [Fact]
        public void NotEmptyInitialSetNonCommonElementTest()
        {
            ISet<string> result = new HashSet<string> { "a", "b", "c" };
            ISet<string> subMask = new HashSet<string> { "d" , "e"};

            new OrSetOperator().SpecificOperation(result, subMask);
            Check.That(result).IsEquivalentTo("a", "b", "c" , "d" , "e");
        }


        [Fact]
        public void EmptyInitialSetTest()
        {
            ISet<string> result = new HashSet<string> { };
            ISet<string> subMask = new HashSet<string> {"z" , "y" };

            new OrSetOperator().SpecificOperation(result, subMask);
            Check.That(result).IsEquivalentTo("z" , "y");
        }


        [Fact]
        public void TestFullFunctionalityOfOrOnInvertedIndexWithHello()
        {
            ISet<string> initial = IndexMap["hello"];
            ISet<string> result =
                new OrSetOperator().Operate(initial, new List<string> { "hi", "world" }, Indexes);
            Check.That(result).IsEquivalentTo("1" , "2" , "3" , "4");

        }

        [Fact]
        public void TestFullFunctionalityOfOrOnInvertedIndexWithHi()
        {
            ISet<string> initial = IndexMap["hi"];
            ISet<string> result =
                new OrSetOperator().Operate(initial, new List<string> { "world"}, Indexes);
            Check.That(result).IsEquivalentTo( "2", "3", "4");


        }

    }
}