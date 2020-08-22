using System.Collections.Generic;
using Nest;

namespace InvertedIndex.QueryProcessor
{
    public interface IQueryProccesor
    {
        List<string> PerformSearch(string input, IElasticClient client, string indexName);
    }
}