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
            Student[] students = JsonConvert.DeserializeObject<Student[]>(json);
            return students;
        }
        public float TryParseInput__Float(string input, string prompt, string line)
        {
            float avgResult = 0;
            if (line == "avgresult")
            {
                bool flag = true;
                do
                {
                    try
                    {
                        if (int.Parse(input) != 0 && float.Parse(input) == 0)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            avgResult = float.Parse(input);
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
            if (name == "course" || name == "institute" || name == "group")
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

