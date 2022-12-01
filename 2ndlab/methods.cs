using System.Globalization;
using Newtonsoft.Json;
using student;
namespace methods {
    class Methods {

        public void SaveSerializedJSON(Student[] students)
        {
            string json = JsonConvert.SerializeObject(students);
            File.WriteAllText(@"C:\\Users\\nikgl\\Desktop\\labradornye\\2ndlab\\2ndlab\\students.json", json);

        }
        public Student[] RefreshStudentListState()
        {
            string json = File.ReadAllText(@"C:\\Users\\nikgl\\Desktop\\labradornye\\2ndlab\\2ndlab\\students.json");
            if (json == "")
            {
                json = "[{}]";
            }
            Student[] students = JsonConvert.DeserializeObject<Student[]>(json);
            return students;
        }
        public void OutputStudentsMatrix(Student[][] students)
        {
            for(int i = 0; i<students.Length; i++)
            {
                StudentMethods.OutputStudentList(students[i]);
                Console.WriteLine();
            }
        }
        public float TryParseInput__Float(string input, string prompt, string line)
        {
            float avgResult = 0;
            if (line == "avgmark")
            {
                bool flag = true;
                do
                {
                    try
                    {
                        if(float.Parse(input)==0.0f)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            avgResult = float.Parse(input);
                            flag=false;
                        }
                    }
                    catch
                    {
                        Console.WriteLine(prompt);
                        input = Console.ReadLine();
                    }
                } while (flag);
            }
            return avgResult;
        }
        public int TryParse__Int(string input, string prompt, string line) {
            int debts = new int();
            if (line == "debts")
            {
                bool flag = true;
                while (flag)
                {
                    try
                    {
                        debts = int.Parse(input);
                        flag = false;
                    }
                    catch
                    {
                        Console.WriteLine(prompt);
                        input = Console.ReadLine();
                    }
                }

            }
            return debts;
        }
        public DateTime TryParseInput__Date(string input, string prompt, string line)
        {
            DateTime BirthdayDate = new DateTime();
            if (line == "birthdayDate")
            {
                bool flag = true;
                while(flag)
                {
                    try
                    {
                        BirthdayDate= DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.GetCultureInfo("es-ES"));
                        flag = false;
                    }
                    catch
                    {
                        Console.WriteLine(prompt);
                        input = Console.ReadLine();
                    }
                }
            
            }
            return BirthdayDate; 
        }
        public string TryParseInput__string(string input, string prompt, string name)
        {
            if (name == "fullname")
            {
                bool flag = true;
                do
                {
                    try
                    {
                        if (input.Trim().Split(" ").Length == 2)
                        {
                            flag = false;
                            return input.Trim();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        Console.WriteLine(prompt);
                        input = Console.ReadLine();
                    }
                } while (flag);
            }
            if (name == "course" || name == "institute" || name == "group" || name == "educationalform" || name == "qualification")
            {
                bool flag = true;
                do
                {
                    try
                    {
                        if (input.Trim().Length != null)
                        {
                            flag = false;
                            return input.Trim();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        input = Console.ReadLine();
                        Console.Write(prompt);
                    }
                } while (flag);
            }
            return input;
        }
    }
}

