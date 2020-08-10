using System;
using System.Collections.Generic;
using StudentAndScore.Model;

namespace StudentAndScore.View
{
    class ConsolePrinter
    {
        public void PrintStudentsWithAverage(List<StudentAverageModel> studentWithAverages)
        {
            foreach (var studentWithAverage in studentWithAverages)
            {
                Console.WriteLine(
                    $"{studentWithAverage.Student.FirstName} {studentWithAverage.Student.LastName} with average {studentWithAverage.Average}");
            }
        }
    }
}