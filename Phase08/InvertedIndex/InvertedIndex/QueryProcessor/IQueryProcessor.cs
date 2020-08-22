using System.Collections.Generic;
using Nest;

namespace InvertedIndex.QueryProcessor
{
    public interface IQueryProccesor
    {
        IEnumerable<string> PerformSearch(string input, int numberToTake = 10);
    }
}