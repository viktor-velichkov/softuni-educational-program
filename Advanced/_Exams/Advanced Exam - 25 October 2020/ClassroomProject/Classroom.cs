using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        List<Student> students = new List<Student>();
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
        }
        public int Capacity { get; set; }
        public int Count { get { return students.Count; } }
        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }
        public string DismissStudent(string firstName, string lastName)
        {
            bool success = students.Remove(students.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault());
            if (success)
            {
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }
        public string GetSubjectInfo(string subject)
        {
            var studentsToShow = students.Where(x => x.Subject == subject).ToArray();
            if (studentsToShow.Count()>0)
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine($"Subject: {subject}");
                result.AppendLine("Students:");
                foreach (var student in studentsToShow)
                {
                    result.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return result.ToString().Trim();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }
        public int GetStudentsCount()
        {
            return students.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            return students.Where(x => x.FirstName == firstName && x.LastName == lastName).ToArray().First();
        }
    }
}
