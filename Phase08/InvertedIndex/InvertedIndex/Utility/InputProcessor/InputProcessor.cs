﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace InvertedIndex.Utility.InputProcessor
{
    public class InputProcessor : IInputProcessor
    {

        private static readonly Regex AndRegex = new Regex("(?: |^)(\\w+)");
        private static readonly Regex OrRegex = new Regex("\\+(\\w+)");
        private static readonly Regex SubtractRegex = new Regex("\\-(\\w+)");

        public List<string> AndStrings { get; set; } = new List<string>();
        public List<string> OrStrings { get; set; } = new List<string>();
        public List<string> SubtractStrings { get; set; } = new List<string>();


        public void ProcessInput(string input)
        {
            AndStrings = ExtractWords(input, AndRegex);
            OrStrings = ExtractWords(input, OrRegex);
            SubtractStrings = ExtractWords(input, SubtractRegex);
        }

        public List<string> ExtractWords(string input, Regex regex)
        {
            return regex.Matches(input).Select(m => m.Groups[1].Value).ToList();
        }

    }
}