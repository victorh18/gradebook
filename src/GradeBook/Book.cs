using System.Text;

namespace GradeBook {
    public class Book {
        public List<double> Grades;
        public string Name;

        public Book(string name)
        {
            Name = name;
            Grades = new List<double>();
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public void AddGrade(double grade) {
            if (grade <= 100 && grade > 0)
            {
                Grades.Add(grade);
            } else {
                throw new ArgumentException($"Invalid {nameof(grade)} value. {nameof(grade)} should be between 0 and 100.");
            }
            
        }

        public Statistics GetStatistics() {
            var stats = new Statistics { 
                Max = Grades.Max(),
                Min = Grades.Min(),
                Average = Grades.Average()
            };

            switch (stats.Average)
            {
                case var d when d >= 90:
                    stats.Letter = 'A';
                    break;
                case var d when d >= 80:
                    stats.Letter = 'B';
                    break;
                case var d when d >= 70:
                    stats.Letter = 'C';
                    break;
                case var d when d >= 60:
                    stats.Letter = 'D';
                    break;
                default:
                    stats.Letter = 'F';
                    break;
            };

            return stats;
        }

        public string GetGradeList() {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < Grades.Count; i++)
            {
                stringBuilder.Append($"#{(i + 1).ToString()}:\t {Grades[i]} \t");
                if ((i + 1) % 3 == 0)
                {
                    stringBuilder.Append(Environment.NewLine);
                }
            } 
            return stringBuilder.ToString();

        }

        public static void Greet(string name)
        {
            System.Console.WriteLine($"Welcome to the grading report application, {name}!");
        }
    }
}