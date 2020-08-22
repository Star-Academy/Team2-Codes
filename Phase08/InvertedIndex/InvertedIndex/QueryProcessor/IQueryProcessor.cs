using System.Collections.Generic;

namespace InvertedIndex.QueryProcessor
{
    public interface IQueryProcessor
    {
        IEnumerable<string> PerformSearch(string input, int numberToTake = 10);
    }
}