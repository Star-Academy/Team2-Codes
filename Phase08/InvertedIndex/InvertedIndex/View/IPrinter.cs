using System;
using System.Collections.Generic;

namespace InvertedIndex.View
{
    interface IPrinter
    {
        public void ShowException(Exception exception);
        public void ShowMessage(string message);
        public void ShowResult(IEnumerable<string> resultList);
    }
}
