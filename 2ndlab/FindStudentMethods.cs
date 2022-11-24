using student;
using System.Text;

namespace findstudent
{
    class FindStudentMethods
    {
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
    }
}