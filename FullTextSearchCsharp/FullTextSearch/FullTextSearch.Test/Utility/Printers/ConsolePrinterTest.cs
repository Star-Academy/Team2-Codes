using System;
using System.Collections.Generic;
using System.IO;
using FullTextSearch.Utility.Printers;
using Xunit;

namespace FullTextSearch.Test.Utility.Printers
{
    public class ConsolePrinterTest
    {
        private readonly StringWriter stringWriter = new StringWriter();

        public ConsolePrinterTest()
        {
            stringWriter.NewLine = "\n";
            /*Windows use \r\n for new line by default and unix use \n. both give the same result visually but string equality
             will be different. I set it to use \n for the test even for Windows so we can also check the presence of next line
              in both UNIX and Windows */
            Console.SetOut(stringWriter);
            
        }

        [Fact]
        public void ShowStringsTest()
        {
            IEnumerable<string> TestStrings = new List<string> {"Hello", "World", "Amir", "Javad"};
            var expected = "Hello World Amir Javad \n";
            new ConsolePrinter().ShowStrings(TestStrings);
            Assert.Equal(expected, stringWriter.ToString());
        }
    }
}