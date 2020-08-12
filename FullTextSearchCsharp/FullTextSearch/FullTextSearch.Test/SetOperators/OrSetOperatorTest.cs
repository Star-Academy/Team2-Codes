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
                new OrSetOperator().Operate(initial, new HashSet<string> { "hi", "world" }, Indexes);
            Check.That(result).IsEquivalentTo("1" , "2" , "3" , "4");

        }

        [Fact]
        public void TestFullFunctionalityOfOrOnInvertedIndexWithHi()
        {
            ISet<string> initial = IndexMap["hi"];
            ISet<string> result =
                new OrSetOperator().Operate(initial, new HashSet<string> { "world"}, Indexes);
            Check.That(result).IsEquivalentTo( "2", "3", "4");


        }

    }


    // @Test
    // public void notEmptyInitialSetCommonElementTest()
    // {
    // Set<String> result = new HashSet<>(Arrays.asList("a", "b", "c"));
    // Set<String> orMask = new HashSet<>(Arrays.asList("a", "b"));
    // new OrSetOperator().specificOperation(result, orMask);
    // org.assertj.core.api.Assertions.assertThat(result).containsOnly("a", "b", "c");
    // }
    //
    // @Test
    // public void notEmptyInitialSetNonCommonElementTest()
    // {
    // Set<String> result = new HashSet<>(Arrays.asList("a", "b", "c"));
    // Set<String> orMask = new HashSet<>(Arrays.asList("d", "e"));
    // new OrSetOperator().specificOperation(result, orMask);
    // org.assertj.core.api.Assertions.assertThat(result).containsOnly("a", "b", "c", "d", "e");
    // }
    //
    // @Test
    // public void EmptyInitialSetTest()
    // {
    // Set<String> result = new HashSet<>();
    // Set<String> orMask = new HashSet<>(Arrays.asList("z", "y"));
    // new OrSetOperator().specificOperation(result, orMask);
    // org.assertj.core.api.Assertions.assertThat(result).containsOnly("z", "y");
    // }
    //
    // @Test
    // public void testFullFunctionalityOfOrOnInvertedIndex()
    // {
    // InvertedIndex invertedIndex = mock(InvertedIndex.class);
    //
    // when(invertedIndex.getIndices()).thenReturn(indexMap);
    //
    // Set<String> initial = indexMap.get("hello");
    // Set<String> result = new OrSetOperator().operate(initial, Arrays.asList("hi", "world"), invertedIndex);
    // org.assertj.core.api.Assertions.assertThat(result).containsOnly("1","2","3","4","5");
    //
    //
    // }
}