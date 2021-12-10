class Program
    {
        const string CFd = "Students.txt";
        const string CFr = "Results.txt";
        
        static void Read(string fv, ref Faculty faculty)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string facultyName = line;
                faculty.SetName(facultyName);
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string nameS = parts[0];
                    string group = parts[1];
                    int numberOfGrades = int.Parse(parts[2]);
                    string[] grades = parts[3].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Student student = new Student(nameS, group, numberOfGrades);
                    foreach (string g in grades)
                    {
                        int grade = int.Parse(g);
                        student.AddGrade(grade);
                    }
                    faculty.Add(student);
                }
            }
        }

        static void Print(string header, string fv, Faculty faculty)
        {
            string top =
             "----------------------------------------------------------------------------------------\r\n"
             + " Name and Surname   Group   Average Group Evaluation   Number of Marks        Marks \r\n"
             + "----------------------------------------------------------------------------------------";
            using (StreamWriter writer = new StreamWriter(fv, true))
            {
                writer.WriteLine(header);
                writer.WriteLine(top);
                for (int i = 0; i < faculty.Get(); i++)
                    writer.WriteLine("{0}", faculty.Get(i).ToString());
                writer.WriteLine("----------------------------------------------------------------------------------------\r\n");
            }
        }
        
        static void Main(string[] args)
        {
            if (File.Exists(CFr)) File.Delete(CFr);
            Faculty faculty = new Faculty();
            Read(CFd, ref faculty);
            Print("Initial data for students of: " + faculty.GetName(), CFr, faculty);
            faculty.FindAverageOfEachGroup();
            Faculty facultySorted = new Faculty();
            facultySorted = faculty;
            facultySorted.Sort();
            Print("Data about students (sorted) of: " + facultySorted.GetName(), CFr, facultySorted);
        }
    }
