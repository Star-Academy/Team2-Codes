using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FullTextSearch.Model;

namespace FullTextSearch.Utility.Readers
{
    public class FileReader : IReader
    {
        public string FilePath { get; }

        public ISet<string> AllFilesInFolder { get; } = new HashSet<String>();

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
            var text = File.ReadAllText(FilePath + "\\" + path).ToLower();
            return text;
        }


        public List<Document> GetDocuments()
        {
            var documents = new List<Document>();
            foreach (var filePath in AllFilesInFolder)
            {
                var text = ReadOneFile(filePath);
                var document = new Document {Id = filePath, Content = text};
                documents.Add(document);
            }

            return documents;
        }
    }
}