﻿using System.Collections.Generic;
using InvertedIndex.Models;

namespace InvertedIndex.Utility.Readers
{
    public interface IReader
    {
        List<Document> GetDocuments();
    }
}