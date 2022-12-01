using student;
using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using methods;

namespace findstudent
{
    class FindStudentMethods
    {
        static Methods methods = new Methods();
        public Student[] BirthdaySearch(Student[] students, string birthdaydate)
        {
            Console.WriteLine("ENTER THE DATE OF STUDENT YOU WANT TO FIND");
            List<Student> foundStudents = new List<Student>();
            DateTime correctDate= methods.TryParseInput__Date(birthdaydate, "enter the correct date. example: 25-12-2012", "birthdayDate");
            for(int i=0; i < students.Length; i++)
            {
                if(correctDate.Ticks == students[i].BirthdayDate.Ticks)
                {
                    foundStudents.Add(students[i]);
                }
            }
            return foundStudents.ToArray();
        }
        public Student[] FindMaxAvgmarkedStudent(Student[] students)
        {
            List<Student> maxAVGMakedStudents = new List<Student> { students[0] };
            for(int i=0; i < students.Length;i++)
            {
                if (maxAVGMakedStudents[0].AvgMark == students[i].AvgMark)
                {
                    maxAVGMakedStudents.Add(students[i]);
                } else if (maxAVGMakedStudents[0].AvgMark < students[i].AvgMark)
                {
                    maxAVGMakedStudents.Clear();
                    maxAVGMakedStudents.Add(students[i]);
                }
            }
            return maxAVGMakedStudents.ToArray();
        }
        public Student[] FindMinAvgmarkedStudent(Student[] students)
        {
            List<Student> maxAVGMakedStudents = new List<Student> { students[0] };
            for (int i = 0; i < students.Length; i++)
            {
                if (maxAVGMakedStudents[0].AvgMark == students[i].AvgMark)
                {
                    maxAVGMakedStudents.Add(students[i]);
                }
                else if (maxAVGMakedStudents[0].AvgMark > students[i].AvgMark)
                {
                    maxAVGMakedStudents.Clear();
                    maxAVGMakedStudents.Add(students[i]);
                }
            }
            return maxAVGMakedStudents.ToArray();
        }
        public Student[][] theSameAvgMarkStudentsSearch(Student[] students)
        {
            Student[][] foundStudentsMatrix = { };
            List<float> usedAvgMarks = new List<float>();
            for(int i = 0; i< students.Length-1; i++)
            {
                if (usedAvgMarks.IndexOf(students[i].AvgMark) != -1){
                    continue;
                }
                Student[] foundStudents = { };
                for(int j = i; j<students.Length; j++)
                {
                    if (students[i].AvgMark == students[j].AvgMark)
                    {
                        foundStudents = StudentMethods.AppendStudent(foundStudents, students[j]);
                    }
                }
                if (foundStudents.Length > 1)
                {
                    usedAvgMarks.Add(students[i].AvgMark);
                    foundStudentsMatrix = StudentMethods.AppendStudent(foundStudentsMatrix, foundStudents);
                }
            }
            return foundStudentsMatrix;
        }
        public Student[] SurnameSearch(Student[] students, string halfSurname)
        {
            List<Student> foundStudents = new List<Student>();
            foreach (Student student in students) {
                string[] splittedFullName = student.FullName.Split(" ");
                for(int i = 0; i < splittedFullName.Length; i++)
                {
                    if (splittedFullName[i].Contains(halfSurname))
                    {
                        foundStudents.Add(student);
                        break;
                    }
                }
            }
            return foundStudents.ToArray();
        }
        public void AdvancedSurnameSearch(Student[] students)
        {
            StringBuilder sb = new StringBuilder();
            ConsoleKeyInfo input;
            do
            {
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length != 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Clear();
                        Console.WriteLine(sb.ToString());
                        StudentMethods.OutputStudentList(SurnameSearch(students, sb.ToString()));
                    }
                }
                else
                {
                    sb.Append(input.KeyChar);
                    Console.Clear();
                    Console.WriteLine(sb.ToString());
                    StudentMethods.OutputStudentList(SurnameSearch(students, sb.ToString()));
                }

            } while (input.Key != ConsoleKey.Enter);
        }
        public Student[] RemoveIdenticalStudents(Student[] students)
        {
            List<Student> newStudents = new List<Student>();
            for(int i = 0; i<students.Length-1; i++)
            {
                int c = 0;
                for(int j = i+1; j < students.Length; j++)
                {
                    if (students[i].FullName == students[j].FullName)
                    {
                        c++;
                    }
                }
                if (c == 0)
                {
                    newStudents.Add(students[i]);
                }
            }
            return newStudents.ToArray();
        } 
    }
}