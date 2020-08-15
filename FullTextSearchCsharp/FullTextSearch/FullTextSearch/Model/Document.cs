using System.Collections.Generic;

namespace FullTextSearch.Model
{
    public class Document
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public ISet<string> TokenizedWords { get; set; }

    }
}
