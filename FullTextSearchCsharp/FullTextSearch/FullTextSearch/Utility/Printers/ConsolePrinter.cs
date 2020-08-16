using System.Collections.Generic;

namespace FullTextSearch.Utility.Printers
{
    public class ConsolePrinter : IPrinter
    {
        public void ShowStrings(IEnumerable<string> strings)
        {
            foreach (var str in strings)
            {
                System.Console.Write($"{str} ");
            }

            System.Console.WriteLine();
        }
    }
}