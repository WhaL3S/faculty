class Faculty
    {
        const int Cmax = 50;
        private Student[] Students;
        private int n;
        private string name;

        public Faculty()
        {
            n = 0;
            Students = new Student[Cmax];
        }
        public void SetName(string name) { this.name = name; }
        public string GetName() { return name; }
        public Student Get(int i) { return Students[i]; }
        public int Get() { return n; }
        public void Add(Student student) { Students[n++] = student; }
        public void Sort()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Student min = Students[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (Students[j] <= min)
                    {
                        min = Students[j];
                        im = j;
                    }
                }
                Students[im] = Students[i];
                Students[i] = min;
            }
        }
        public double Summarizer(int number, double sum)
        {
            for (int i = 0; i < Students[number].GetNumberOfGrade(); i++)
            {
                sum = sum + Students[number].GetGrade(i);
            }
            return sum;
        }
        public void FindAverageOfEachGroup()
        {
            string tempGroupName = " ";
            for (int i = 0; i < n; i++)
            {
                string groupName = Students[i].GetGroup();
                if (groupName != tempGroupName)
                {
                    double sum = 0;
                    double counter = 0;
                    double average = 0;
                    sum = Summarizer(i, sum);
                    counter = counter + Students[i].GetNumberOfGrade();

                    for (int j = 0; j < n; j++)
                    {
                        if (i != j && groupName == Students[j].GetGroup())
                        {
                            sum = Summarizer(j, sum);
                            counter = counter + Students[j].GetNumberOfGrade();
                            tempGroupName = Students[j].GetGroup();
                        }
                    }
                    average = sum / counter;
                    for (int k = 0; k < n; k++)
                    {
                        if (groupName == Students[k].GetGroup())
                        {
                            Students[k].SetAverageByGroup(average);
                        }
                    }
                }
            }
        }
    }
