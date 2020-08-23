using System;
using System.Collections.Generic;

namespace InvertedIndex.View
{
    public class ConsolePrinter : IPrinter
    {
        public void ShowException(Exception exception , int? errorCode = null)
        {
            
            Console.WriteLine("Exception Occured:");
            if (errorCode != null)
            {
                Console.WriteLine($"Error Code: {errorCode}");
            }
            Console.WriteLine(exception.Message);
            Console.WriteLine("-----------------");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowResult(IEnumerable<string> resultList)
        {
            Console.WriteLine("Result:");
            foreach (var str in resultList)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("-----------------");
        }
    }
}