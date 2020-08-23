using System;
using System.Collections.Generic;

namespace InvertedIndex.View
{
    interface IPrinter
    {
        public void ShowException(Exception exception , int? errorCode = null);
        public void ShowMessage(string message);
        public void ShowResult(IEnumerable<string> resultList);
    }
}
