using student;
using System.Diagnostics;

namespace showallstudents
{
    public class ShowAllStudentsTask
    {
        public void ShowAllStudents(Student[] students)
        {
            StudentMethods.OutputStudentList(students);
        }
    }
}