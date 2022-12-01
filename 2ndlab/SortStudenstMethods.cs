using student;
namespace sortstudentmethods
{
    class SortStudentsMethods
    {
        public Student[] AvgSort(Student[] students, int leftIndex, int rightIndex)
        {
                var i = leftIndex;
                var j = rightIndex;
                var pivot = students[leftIndex].AvgMark;

                while (i <= j)
                {
                    while (students[i].AvgMark < pivot)
                    {
                        i++;
                    }

                    while (students[j].AvgMark > pivot)
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                        i++;
                        j--;
                    }
                }

                if (leftIndex < j)
                    AvgSort(students, leftIndex, j);

                if (i < rightIndex)
                    AvgSort(students, i, rightIndex);

                return students;
        }
    }
}