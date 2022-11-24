using student;
namespace findstudent
{
    class FindStudentMethods
    {
        public int[] SurnameSearch(Student[] students, string halfSurname)
        {
            List<int> foundIDStudents = new List<int>();
            foreach (Student student in students) {
                string[] splittedFullName = student.FullName.Split(" ");
                for(int i = 0; i < splittedFullName.Length; i++)
                {
                    if (splittedFullName[i] == halfSurname)
                    {
                        foundIDStudents.Add(i);
                    }
                }
            }
            return foundIDStudents.ToArray();
        }
    }
}