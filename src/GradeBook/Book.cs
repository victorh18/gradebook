namespace GradeBook {
    public class Book {
        List<double> grades;
        public string Name;

        public Book(string name)
        {
            Name = name;
            grades = new List<double>();
        }
        public void AddGrade(double grade) {
            grades.Add(grade);
        }

        public Statistics GetStatistics() {
            return new Statistics { 
                Max = grades.Max(),
                Min = grades.Min(),
                Average = grades.Average()
            };
        }

        public string GetGradeList() {
            return string.Join(", ", grades);

        }

        public static void Greet(string name)
        {
            System.Console.WriteLine($"Welcome to the grading report application, {name}!");
        }
    }
}