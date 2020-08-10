using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace StudentAndScore.Utility
{
    class FileReader
    {
        public static List<T> GetListFromJsonFile<T>(string path)
        {
            var rawJsonText = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(rawJsonText);
        }
    }
}