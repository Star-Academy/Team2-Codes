using System.Collections.Generic;

namespace FullTextSearch.QueryProcessors
{
    public interface IQueryProcessor
    {
        List<string> PerformSearch(string input);
    }
}