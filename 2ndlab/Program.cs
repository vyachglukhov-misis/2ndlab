using KeyboardMenu;
using student;
using methods;
using showallstudents;
using addstudent;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using findstudent;

namespace SecondLab
{

    class SecondLab
    {
        static AddNewStudentTask AddNewStudent = new AddNewStudentTask();
        static ShowAllStudentsTask ShowStudents = new ShowAllStudentsTask();
        static Methods methods = new Methods();
        static Student[] students = methods.RefreshStudentListState();

        public static void StartMainMenu()
        {

            string startPrompt = "Lab #2 Vyach Glukhov. MISIS 2022";
            string[] options = { "ADD STUDENT", "SHOW ALL STUDENTS", "FIND USERS" , "REMOVE IDENTICAL STUDENTS"};
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
        private static void RunShowAllStudentsTask()
        {
            Console.Clear();
            ShowStudents.ShowAllStudents(students);
            Console.WriteLine("Press any key to return for main menu");
            Console.ReadKey(true);
            StartMainMenu();
        }
        private static void RunSubMenuSearch()
        {
            FindStudentMethods findStudentMethods = new FindStudentMethods();
            Console.Clear();
            string subMenuPrompt = "Select the option by the one you want to find student";
            string[] options = { "SURNAME SEARCH", "BDAY DATE SEARCH", "FIND MAX AND MIN AVERAGE MARK`S STUDENTS", "RETURN TO MAIN MENU" };
            Menu subSearchMenu = new Menu(subMenuPrompt, options);
            int selectedIndex = subSearchMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    ReturnToMainMenu();
                    break;
            }
            void ReturnToMainMenu()
            {
                Console.Clear();
                StartMainMenu();
            }
            void RunSurnameSearch()
            {
                Console.Clear();
            }
            void SurnameSearch()
            {

            }
        }
        public static void Main(string[] args)
        {
            StartMainMenu();
        }
    }
}