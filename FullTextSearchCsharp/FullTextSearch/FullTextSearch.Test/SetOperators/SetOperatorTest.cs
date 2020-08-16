using System.Collections.Generic;
using FullTextSearch.Model;
using Moq;

namespace FullTextSearch.Test.SetOperators
{
    public abstract class SetOperatorTest
    {
        protected IDictionary<string, ISet<string>> IndexMap = new Dictionary<string, ISet<string>>();
        protected InvertedIndex Indexes;
        protected SetOperatorTest()
        {
            MakeIndexMap();
            MakeMockInvertedIndex();
        }

        private void MakeIndexMap()
        {
            ISet<string> helloIndex = new HashSet<string> {"1", "2", "3", "4"};
            ISet<string> worldIndex = new HashSet<string> {"2", "3"};
            ISet<string> hiIndex = new HashSet<string> {"2", "4"};

            IndexMap.Add("hello", helloIndex);
            IndexMap.Add("world", worldIndex);
            IndexMap.Add("hi", hiIndex);
        }

        private void MakeMockInvertedIndex()
        {
            var invertedIndex = new Mock<InvertedIndex>();
            invertedIndex.SetupAllProperties();
            invertedIndex.Object.Indexes = IndexMap;
            Indexes = invertedIndex.Object;
        }

    }
}