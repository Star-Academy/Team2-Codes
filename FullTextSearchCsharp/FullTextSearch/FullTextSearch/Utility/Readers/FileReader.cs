﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FullTextSearch.Model;

namespace FullTextSearch.Utility.Readers
{
    public class FileReader : IReader
    {
        public string FilePath { get; }

        public ISet<string> AllFilesInFolder { get; } = new HashSet<string>();

        public FileReader(string filePath)
        {
            FilePath = filePath;
            ListAllFilesInFolder();
        }

        public void ListAllFilesInFolder()
        {
            AllFilesInFolder.UnionWith(Directory.GetFiles(FilePath).Select(file => Path.GetFileName(file)));
        }

        public string ReadOneFile(string path)
        {

            var text = File.ReadAllText($"{FilePath}/{path}").ToLower();
            
            return text;
        }


        public List<Document> GetDocuments()
        {
            var documents = AllFilesInFolder.OrderBy(filePath => filePath).Select(filePath =>
            {
                var text = ReadOneFile(filePath);
                return new Document() { Id = filePath, Content = text };
            }).ToList();

            return documents;
        }
    }
}