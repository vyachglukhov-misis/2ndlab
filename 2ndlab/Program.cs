using KeyboardMenu;
using student;
using methods;
using showallstudents;
using addstudent;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using findstudent;
using sortstudentmethods;
using System.Reflection.Metadata;

namespace SecondLab
{

    class SecondLab
    {
        static AddNewStudentTask AddNewStudent = new AddNewStudentTask();
        static ShowAllStudentsTask ShowStudents = new ShowAllStudentsTask();
        static SortStudentsMethods sortStudentsMethods= new SortStudentsMethods();
        static Methods methods = new Methods();
        static FindStudentMethods findStudentMethods = new FindStudentMethods();
        static Student[] students = methods.RefreshStudentListState();

        public static void StartMainMenu()
        {

            string startPrompt = "Lab #2 Vyach Glukhov. MISIS 2022";
            string[] options = { "ADD STUDENT", "SHOW ALL STUDENTS", "FIND STUDENTS", "SORT BY AVG MARK" , "REMOVE IDENTICAL STUDENTS", "EXIT"};
            Menu mainMenu = new Menu(startPrompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunAddStudentTask();
                    break;
                case 1:
                    RunShowAllStudentsTask();
                    break;
                case 2:
                    RunSubMenuSearch();
                    break;
                case 3:
                    RunSortStudentsAvgMark();
                    break;
                case 4:
                    RunRemoveIdenticalStudents();
                    break;
                case 5:
                    Exit();
                    break;
            }

        }
        private static void RunAddStudentTask()
        {
            Console.Clear();
            AddNewStudent.AddNewStudent(ref students);
            methods.SaveSerializedJSON(students);
            Console.WriteLine("Press any key to return for main menu");
            Console.ReadKey(true);
            StartMainMenu();
        }
        static private void Exit()
        {
            Environment.Exit(0);
        }
        private static void RunShowAllStudentsTask()
        {
            Console.Clear();
            ShowStudents.ShowAllStudents(students);
            Console.WriteLine("Press any key to return for main menu");
            Console.ReadKey(true);
            StartMainMenu();
        }
        private static void RunSortStudentsAvgMark() {
            Console.Clear();
            StudentMethods.OutputStudentList(sortStudentsMethods.AvgSort(students, 0, students.Length - 1));
            Console.WriteLine("Press any key to return for main menu");
            Console.ReadKey(true);
            StartMainMenu();

        }
        private static void RunRemoveIdenticalStudents()
        {
            FindStudentMethods findStudentMethods= new FindStudentMethods();
            Console.Clear();
            Student[] newStudentList = findStudentMethods.RemoveIdenticalStudents(students);
            StudentMethods.OutputStudentList(newStudentList);
            methods.SaveSerializedJSON(newStudentList);
            students = methods.RefreshStudentListState();
            Console.WriteLine("Identical students were removed from Student list. Press any key to return main menu...");
            Console.ReadKey(true);
            StartMainMenu();
        }
        private static void RunSubMenuSearch()
        {
            Console.Clear();
            string subMenuPrompt = "Select the option by the one you want to find student";
            string[] options = { "SURNAME SEARCH", "BDAY DATE SEARCH", "FIND MAX AND MIN AVERAGE MARK`S STUDENTS","FIND THE SAME AVGMARKED STUDENTS",  "RETURN TO MAIN MENU" };
            Menu subSearchMenu = new Menu(subMenuPrompt, options);
            int selectedIndex = subSearchMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunSurnameSearch();
                    break;
                case 1:
                    RunBirthDaySearch();
                    break;
                case 2:
                    RunMaxAVGMarkedStudents();
                    break;
                case 3:
                    RunTheSameAvgMarkedStudents();
                    break;
                case 4:
                    ReturnToMainMenu();
                    break;
            }
            void RunBirthDaySearch()
            {
                Console.Clear();
                StudentMethods.OutputStudentList(findStudentMethods.BirthdaySearch(students, Console.ReadLine()));
                Console.WriteLine("Press any key to return for main menu");
                Console.ReadKey(true);
                RunSubMenuSearch();
            }
            void ReturnToMainMenu()
            {
                Console.Clear();
                StartMainMenu();
            }
            void RunMaxAVGMarkedStudents(){
                Console.Clear();
                Console.WriteLine("MAX AVGMARKED STUDENTS");
                StudentMethods.OutputStudentList(findStudentMethods.FindMaxAvgmarkedStudent(students));
                Console.WriteLine();
                Console.WriteLine("MIN AVGMARKED STUDENTS");
                StudentMethods.OutputStudentList(findStudentMethods.FindMinAvgmarkedStudent(students));
                Console.WriteLine("Press any key to return for main menu");
                Console.ReadKey(true);
                RunSubMenuSearch();
            }
            void RunSurnameSearch()
            {
                Console.Clear();
                findStudentMethods.AdvancedSurnameSearch(students);
                RunSubMenuSearch();
            }
            void RunTheSameAvgMarkedStudents()
            {
                Console.Clear();
                methods.OutputStudentsMatrix(findStudentMethods.theSameAvgMarkStudentsSearch(students));
                Console.WriteLine("Press any key to return for main menu");
                Console.ReadKey(true);
                RunSubMenuSearch();
            }
        }
        public static void Main(string[] args)
        {
            StartMainMenu();
        }
    }
}