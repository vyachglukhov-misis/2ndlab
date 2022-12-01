using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using methods;

namespace student
{
    public struct Student
    {
        public long Id;
        public string FullName;
        public DateTime BirthdayDate;
        public string Institute;
        public string Group;
        public string Course;
        public float AvgMark;
        public string EducationalForm;
        public string Qualification;
        public int Debts;

        public Student(long id, string fullName, DateTime birthdayDate, string institute, string group, string course, float avgMark, string educationalForm, string qualification, int debts)
        {
            this.Id = id;
            this.FullName = fullName;
            this.BirthdayDate = birthdayDate;
            this.Institute = institute;
            this.Group = group;
            this.Course = course;
            this.AvgMark = avgMark;
            this.EducationalForm = educationalForm;
            this.Qualification = qualification;
            this.Debts = debts;
        }
    }
    public static class StudentMethods
    {
        static Methods methods = new Methods();
        public static T[] AppendStudent<T>(this T[] students, T student)
        {
            T[] newStudentsList = new T[students.Length + 1];
            students.CopyTo(newStudentsList, 0);
            newStudentsList[students.Length] = student;
            return newStudentsList;
        }
        public static Student CreateNewStudent(int studentListLength)
        {
            Student newStudent = new Student();

            newStudent.Id = DateTime.Now.Ticks;
            Console.WriteLine("Enter student NAME");
            newStudent.FullName = methods.TryParseInput__string(Console.ReadLine(), "enter the correct full name (name and surname)", "fullname");
            Console.WriteLine("Enter student BIRTHDAY DATE in format: dd-MM-yyyy");
            newStudent.BirthdayDate = methods.TryParseInput__Date(Console.ReadLine(), "enter the correct date format. example: 20-06-2004", "birthdayDate");
            Console.WriteLine("Enter student INSTITUTE");
            newStudent.Institute = methods.TryParseInput__string(Console.ReadLine(), "name of institute must include in itself at least one char", "institute");
            Console.WriteLine("etner student GROUP");
            newStudent.Group = methods.TryParseInput__string(Console.ReadLine(), "name of institute must include in itself at least one char", "group");
            Console.WriteLine("enter student AVGMARK");
            newStudent.AvgMark = methods.TryParseInput__Float(Console.ReadLine(), "enter the correct avgMark", "avgmark");
            Console.WriteLine("enter student`s education form");
            newStudent.EducationalForm = methods.TryParseInput__string(Console.ReadLine(), "name of educational form is incorrect", "educationalform");
            Console.WriteLine("enter QUALIFICATION of student");
            newStudent.Qualification = methods.TryParseInput__string(Console.ReadLine(), "name of student`s qualification is incorrect", "qualification");
            Console.WriteLine("enter DEBTS of student");
            newStudent.Debts = methods.TryParse__Int(Console.ReadLine(), "incorrect count of student`s debts. try again.", "debts");

            return newStudent;
        }
        public static void OutputStudentList(Student[] StudentList)
        {
            foreach(Student student in StudentList)
            {
                Console.WriteLine($"NAME: {student.FullName}, ID: {student.Id}, BDAY: {student.BirthdayDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}, INSTITUTE: {student.Institute}, GROUP: {student.Group}, AVGMARK:{student.AvgMark}");
            }
        }
    }
}
