using System.Collections.Generic;
using FullTextSearch.Model;

namespace FullTextSearch.Utility.Readers
{
    public interface IReader
    {
        List<Document> GetDocuments();
    }
}