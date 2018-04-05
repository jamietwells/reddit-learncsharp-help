using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnCSharp {

    public class Program {
        public static void Main(string[] args) {
            foreach (var student in GetStudents()) {
                Console.WriteLine(student.CSVFormat());
                //Console.WriteLine(student.NiceFormat());
            }
        }

        private static IEnumerable<BetterStudent> GetStudents() =>
            Student.Students
                .GroupBy(s => s.Name)
                .Select(s => new BetterStudent(s));
    }

    public class Student {
        public static IEnumerable<Student> Students => new[]
            {
                new Student { Name = "Chad", Course = "ENG1100", Gpa = 3 },
                new Student { Name = "Chad", Course = "BIO2100", Gpa = 3 },
                new Student { Name = "Chad", Course = "CHEM1100", Gpa = 3 },
                new Student { Name = "Sarah", Course = "LIT3460", Gpa = 4 },
                new Student { Name = "Sarah", Course = "MATH2700", Gpa = 4 },
                new Student { Name = "Sarah", Course = "CSCI4700", Gpa = 4 },
                new Student { Name = "Peter", Course = "ENG1100", Gpa = 2 },
                new Student { Name = "Betty", Course = "BIO2100", Gpa = 1 },
                new Student { Name = "Bob", Course = "ART1010", Gpa = 3 },
                new Student { Name = "Bob", Course = "PSY1100", Gpa = 3 }
            };

        public string Name { get; private set; }
        public string Course { get; private set; }
        public int Gpa { get; private set; }
    }

    public class BetterStudent {
        public BetterStudent(IGrouping<string, Student> student) {
            Name = student.Key;
            Course = student.Select(s => s.Course);
            Gpa = student.GroupBy(s => s.Gpa).Select(s => s.Key);
        }
        public string Name { get; }
        public IEnumerable<string> Course { get; }
        public IEnumerable<int> Gpa { get; }
        private string FormattedCourse => string.Join(", ", Course);
        private string FormattedGpa => string.Join(", ", Gpa);

        public override string ToString() => NiceFormat();

        public string CSVFormat() =>
            $"{Name}, {FormattedCourse}, {FormattedGpa}";

        public string NiceFormat() =>
            $"Name: {Name}, Courses: {FormattedCourse}, GPA: {FormattedGpa}";
    }
}