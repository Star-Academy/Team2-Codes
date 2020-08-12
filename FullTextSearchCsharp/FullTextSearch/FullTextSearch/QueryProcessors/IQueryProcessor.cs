using System.Collections.Generic;
using FullTextSearch.Model;

namespace FullTextSearch.QueryProcessors
{
    public interface IQueryProcessor
    {
        List<string> PerformSearch(string input);
    }
}