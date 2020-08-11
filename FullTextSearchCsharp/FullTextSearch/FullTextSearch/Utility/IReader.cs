using System.Collections.Generic;
using FullTextSearch.Model;

namespace FullTextSearch.Utility
{
    public interface IReader
    {
        List<Document> GetDocuments();
    }
}