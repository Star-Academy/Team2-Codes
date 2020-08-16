using System.Collections.Generic;

namespace FullTextSearch.Utility.Printer
{
    public interface IPrinter
    {
        void ShowStrings(IEnumerable<string> strings);
    }
}