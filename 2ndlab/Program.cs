namespace SecondLab
{
    struct Student {
        public int Id;
        public string FullName;
        public DateTime BirthdayDate;
        public string Institute;
        public string Group;
        public string Course;
        public float AvgMark;

        public Student(int id, string fullName, DateTime birthdayDate, string institute, string group, string course, float avgMark)
        {
            this.Id = id;
            this.FullName = fullName;
            this.BirthdayDate = birthdayDate;
            this.Institute = institute;
            this.Group = group;
            this.Course = course;
            this.AvgMark = avgMark;

        }
    }

    class SecondLab {
        public static void Main(string[] args)
        {

        }

    }


}
