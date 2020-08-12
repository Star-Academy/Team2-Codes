using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FullTextSearch.Utility
{
    public class InputProcessor
    {
        public List<string> andStrings { get; set; }
        public List<string> orStrings { get; set; }
        public List<string> subtractStrings { get; set; }

        public void ProcessInput(string input)
        {
            andStrings = ExtractWords(input, "(?: |^)(\\w+)");
            orStrings = ExtractWords(input, "\\+(\\w+)");
            subtractStrings = ExtractWords(input, "\\-(\\w+)");
        }

        public List<string> ExtractWords(string input, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.Matches(input).Cast<Match>().Select(m => m.Groups[1].Value).ToList();
        }

    }
}