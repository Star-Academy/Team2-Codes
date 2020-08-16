using System.Collections.Generic;

namespace FullTextSearch.Utility.Printers
{
    public interface IPrinter
    {
        void ShowStrings(IEnumerable<string> strings);
    }
}