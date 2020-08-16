using System.Collections.Generic;

namespace FullTextSearch.Utility.StringProcessors.InputProcessors
{
    public interface IInputProcessor
    {
         List<string> AndStrings { get; set; } 
         List<string> OrStrings { get; set; }
         List<string> SubtractStrings { get; set; }


         void ProcessInput(string input);


    }
}