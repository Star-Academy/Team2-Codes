using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using StudentAndScore.Model;
using StudentAndScore.Utility;
using StudentAndScore.View;

namespace StudentAndScore
{
    class Program
    {
        private const string StudentJsonPath = "../../../resources/Students.json";
        private const string ScoreJsonPath = "../../../resources/Scores.json";
        private const int NumberOfBestStudentsToTake = 3;

        static void Main(string[] args)
        {
            var students = FileReader.GetListFromJsonFile<Student>(StudentJsonPath);
            var points = FileReader.GetListFromJsonFile<Point>(ScoreJsonPath);
            var bestStudentsWithAverages =
                QueryManager.GetBestStudentsByAverageScore(students, points, NumberOfBestStudentsToTake);

            ConsolePrinter.PrintStudentsWithAverage(bestStudentsWithAverages);
        }
    }
}