using System.Collections.Generic;
using System.Linq;
using StudentAndScore.Model;

namespace StudentAndScore.Utility.Query
{
    class QueryManager
    {
        public List<StudentAverageModel> GetBestStudentsByAverageScore(List<Student> students,
            List<Point> points, int numberToTake = -1)
        {
            var studentsWithAverages = students.GroupJoin(points, student => student.StudentNumber,
                    score => score.StudentNumber,
                    (student, scores) => new StudentAverageModel()
                        {Student = student, Average = scores.Average(s => s.Score)})
                .OrderByDescending(s => s.Average);

            return Paginate(studentsWithAverages, numberToTake);
        }

        private List<T> Paginate<T>(IEnumerable<T> linqQueryEnumerable, int numberToTake = -1)
        {
            if (numberToTake != -1)
            {
                linqQueryEnumerable = linqQueryEnumerable.Take(numberToTake);
            }

            return linqQueryEnumerable.ToList();
        }
    }
}