using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAndScore.Model;

namespace StudentAndScore.Utility
{
    class QueryManager
    {
        public static List<StudentAverageModel> GetBestStudentsByAverageScore(List<Student> students,
            List<Point> points, int numberToTake = -1)
        {
            var studentsWithAverages = students.GroupJoin(points, student => student.StudentNumber,
                    score => score.StudentNumber,
                    (student, scores) => new StudentAverageModel()
                        {Student = student, Average = scores.Select(s => s.Score).Average()})
                .OrderByDescending(s => s.Average);
            if (numberToTake == -1)
            {
                return studentsWithAverages.ToList();
            }
            return studentsWithAverages.Take(numberToTake).ToList();
        }
    }
}