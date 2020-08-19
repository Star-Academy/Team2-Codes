using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Learning.FileReader
{
    class JsonFileReader<T> : IFileReader<T> where T: class
    {
        public string Path { get; set; }

        public IEnumerable<T> GetIEnumerable()
        {
            var json = File.ReadAllText(Path);
            var list = JsonSerializer.Deserialize<List<T>>(json);
            return list;
        }
    }
}
