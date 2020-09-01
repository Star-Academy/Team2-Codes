using System.Collections.Generic;
using InvertedIndex.Models;

namespace InvertedIndex.QueryProcessor
{
    public interface IQueryProcessor
    {
        IEnumerable<string> PerformSearch(string input, int numberToTake = 10 , int page = 1);
        Document GetDocumentByID(int id);
    }
}