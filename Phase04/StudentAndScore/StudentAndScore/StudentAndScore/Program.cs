using StudentAndScore.Model;
using StudentAndScore.Utility.Query;
using StudentAndScore.Utility.Readers;
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
            var reader = new FileReader();
            var students = reader.GetList<Student>(StudentJsonPath);
            var points = reader.GetList<Point>(ScoreJsonPath);

            var manager = new QueryManager();
            var bestStudentsWithAverages =
                manager.GetBestStudentsByAverageScore(students, points, NumberOfBestStudentsToTake);

            var consolePrinter = new ConsolePrinter();
            consolePrinter.PrintStudentsWithAverage(bestStudentsWithAverages);
        }
    }
}