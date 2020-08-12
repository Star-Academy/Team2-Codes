using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FullTextSearch.Utility
{
    public class Tokenizer
    {
        // " ,.;-'()\"@[]><\t\n";

        private readonly char[] separators = new char[]
            {' ', ',', '.', ';', '-', '\'', '(', ')', '\"', '@', '[', ']', '>', '<', '\t', '\n' , '\0'};

        public ISet<string> TokenizeContent(string content)
        {
            var splitted = content.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            splitted.Remove("");

            return new HashSet<string>(splitted);
        }
    }
}