using System;
using System.Collections.Generic;

namespace InvertedIndex.View
{
    public class ConsolePrinter : IPrinter
    {
        private const string ExceptionOccuredExpression = "Exception Occured:";
        private const string ErrorCodeExpression = "Error Code:";
        private const string DashLine = "-----------------";
        private const string ResultExpression = "Result:";
        public void ShowException(Exception exception , int? errorCode = null)
        {
            
            Console.WriteLine(ExceptionOccuredExpression);
            if (errorCode != null)
            {
                Console.WriteLine($"{ErrorCodeExpression} {errorCode}");
            }
            Console.WriteLine(exception.Message);
            Console.WriteLine(DashLine);
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowResult(IEnumerable<string> resultList)
        {
            Console.WriteLine(ResultExpression);
            foreach (var str in resultList)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine(DashLine);
        }
    }
}