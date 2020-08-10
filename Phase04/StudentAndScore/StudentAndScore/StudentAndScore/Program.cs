using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace StudentAndScore
{
    class Program
    {
        private const string StudentJsonPath = "../../../resources/Students.json";
        private const string ScoreJsonPath = "../../../resources/Scores.json";

        static void Main(string[] args)
        {
            var studentsRawString = File.ReadAllText(StudentJsonPath);
            var scoresRawString = File.ReadAllText(ScoreJsonPath);
            var students = JsonSerializer.Deserialize<List<Student>>(studentsRawString);
            var scores = JsonSerializer.Deserialize<List<StudentScore>>(scoresRawString);



            var studentsSorted = students.GroupJoin(scores, student => student.StudentNumber,
                    score => score.StudentNumber,
                    (student, scores) => new {Student = student, Scores = scores})
                .OrderByDescending(s => s.Scores.Select(s => s.Score).Average()).ToList();


            foreach (var myStudent in studentsSorted)
            {
                Console.WriteLine(
                    $"{myStudent.Student.FirstName} {myStudent.Student.LastName} with average {myStudent.Scores.Select(s => s.Score).Average().ToString()}");
            }
        }
    }
}