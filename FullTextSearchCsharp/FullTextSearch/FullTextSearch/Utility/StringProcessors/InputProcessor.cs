using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FullTextSearch.Utility
{
    public class InputProcessor
    {

        private static readonly Regex AndRegex = new Regex("(?: |^)(\\w+)");
        private static readonly Regex OrRegex = new Regex("\\+(\\w+)");
        private static readonly Regex SubtractRegex = new Regex("\\-(\\w+)");

        public List<string> AndStrings { get; set; } = new List<string>();
        public List<string> OrStrings { get; set; } = new List<string>();
        public List<string> SubtractStrings { get; set; } = new List<string>();


        public virtual void ProcessInput(string input)
        {
            AndStrings = ExtractWords(input, AndRegex);
            OrStrings = ExtractWords(input, OrRegex);
            SubtractStrings = ExtractWords(input, SubtractRegex);
        }

        public List<string> ExtractWords(string input, Regex regex)
        {
            return regex.Matches(input).Cast<Match>().Select(m => m.Groups[1].Value).ToList();
        }

    }
}