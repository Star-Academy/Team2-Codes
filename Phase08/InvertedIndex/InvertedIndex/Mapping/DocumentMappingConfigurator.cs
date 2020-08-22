using System;
using System.Collections.Generic;
using System.Text;
using InvertedIndex.Models;
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

        public static PropertiesDescriptor<Document> AddConentMapping(this PropertiesDescriptor<Document> pr)
        {
            return pr.Text(t =>
                t.Name(n => n.Content));
        }

    }
}
