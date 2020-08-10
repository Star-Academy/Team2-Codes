using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace StudentAndScore.Utility.Readers
{
    class FileReader : IReader
    {
        public List<T> GetList<T>(string path)
        {
            var rawJsonText = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(rawJsonText);
        }
    }
}