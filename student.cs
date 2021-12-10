class Student
    {
        private string nameS;
        private string group;
        private int numberOfGrades;
        private int[] Grades;
        private double averageByGroup;

        public Student(string nameS, string group, int numberOfGrades)
        {
            this.nameS = nameS;
            this.group = group;
            this.numberOfGrades = numberOfGrades;
            Grades = new int[numberOfGrades];
        }

        public int GetGrade(int index)
        {
            return (int)Grades[index];
        }

        private int i = 0;

        public void AddGrade(int grade)
        {
            Grades[i++] = grade;
        }

        public string GetNameSurname() { return nameS; }
        public string GetGroup() { return group; }
        public int GetNumberOfGrade() { return numberOfGrades; }
        public double GetAverageByGroup() { return averageByGroup; }
        public void SetAverageByGroup(double averageByGroup) { this.averageByGroup = averageByGroup; }

        public override string ToString()
        {
            string line;
            line = string.Format("{0, 17} {1, 7} {2, 26:f} {3, 10}\t\t\t", nameS, group, averageByGroup, numberOfGrades);
            for (int i = 0; i < numberOfGrades; i++)
                line = line + string.Format("{0, 3}", Grades[i]); 
            return line;
        }
        public static bool operator <=(Student st1, Student st2)
        {
            int p = String.Compare(st1.nameS, st2.nameS, StringComparison.CurrentCulture);
            if((st1.averageByGroup > st2.averageByGroup) || ((st1.averageByGroup == st2.averageByGroup) && (p < 0))) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >=(Student st1, Student st2)
        {
            int p = String.Compare(st1.nameS, st2.nameS, StringComparison.CurrentCulture);
            if ((st1.averageByGroup < st2.averageByGroup) || ((st1.averageByGroup == st2.averageByGroup) && (p > 0)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
