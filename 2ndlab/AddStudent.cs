using student;
namespace addstudent {
    class AddNewStudentTask
    {
        public void AddNewStudent(ref Student[] students)
        {
            students = StudentMethods.AppendStudent(students, StudentMethods.CreateNewStudent(students.Length));
        }
    }
}
