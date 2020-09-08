using System.Collections.Generic;
using InvertedIndex.Models;

namespace InvertedIndex.QueryProcessor
{
    public interface IQueryProcessor
    {
        IEnumerable<Document> PerformSearch(string input, int numberToTake = 10 , int page = 1);
        Document GetDocumentByID(string id);
    }
}