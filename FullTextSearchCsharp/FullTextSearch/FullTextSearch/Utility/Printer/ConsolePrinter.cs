using System.Collections.Generic;

namespace FullTextSearch.Utility.Printer
{
    public class ConsolePrinter : IPrinter
    {
        public void ShowStrings(IEnumerable<string> strings)
        {
            foreach (var str in strings)
            {
                System.Console.Write($"{strings} ");
            }

            System.Console.WriteLine();
        }
    }
}