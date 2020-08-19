using System.Collections.Generic;

namespace Learning.FileReader
{
    public interface IFileReader<T> where T : class
    {
        public string Path { get; set; }

        public IEnumerable<T> GetIEnumerable();
    }
}