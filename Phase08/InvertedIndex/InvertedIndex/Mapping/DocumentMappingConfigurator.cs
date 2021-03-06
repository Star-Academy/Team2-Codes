﻿using InvertedIndex.Models;
using Nest;

namespace InvertedIndex.Mapping
{
    internal static class DocumentFieldsConfigurator
    {
        public static PropertiesDescriptor<Document> AddIdMapping(this PropertiesDescriptor<Document> pr)
        {
            return pr.Text(t =>
                t.Name(n => n.Id));
        }

        public static PropertiesDescriptor<Document> AddContentMapping(this PropertiesDescriptor<Document> pr)
        {
            return pr.Text(t =>
                t.Name(n => n.Content));
        }

    }
}
