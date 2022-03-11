using System.Text;

namespace GradeBook {
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook {
        string Name { get;}
        Statistics GetStatistics();
        event GradeAddedDelegate GradeAdded;
        void AddGrade(double grade);
        string GetGradeList();
    }

    public class NamedObject {
        private string? name;
        public string? Name { 
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"The {nameof(Name)} value cannot be empty");
                }

                name = value;
            }
        }

        public NamedObject(string _name)
        {
            Name = _name;
        }
    }

    public abstract class Book : NamedObject, IBook {
        public Book(string name) : base(name)
        {
            
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);

        public abstract string GetGradeList();

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {        
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override string GetGradeList()
        {
            var counter = 0;
            var stringBuilder = new StringBuilder();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var grade = reader.ReadLine();

                while (grade != null)
                {
                    stringBuilder.Append($"#{(counter + 1).ToString()}:{(((counter + 1) >= 10) ? "" : " ")} {grade} \t");
                    if ((counter + 1) % 3 == 0)
                    {
                        stringBuilder.Append(Environment.NewLine);
                    }
                    grade = reader.ReadLine();
                    counter++;
                }
            }

            return stringBuilder.ToString();
        }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var grade = reader.ReadLine();
                while (grade != null)
                {
                    stats.Add(double.Parse(grade));
                    grade = reader.ReadLine();
                }
            }

            return stats;
        }
    }

    public class InMemoryBook : Book {
        public List<double> Grades;

        public override event GradeAddedDelegate? GradeAdded;

        public InMemoryBook(string _name) : base(_name)
        {
            Name = _name;
            Grades = new List<double>();
        }

        public void AddGrade(char letter)
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
        public override void AddGrade(double grade) {
            if (grade <= 100 && grade > 0)
            {
                Grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            } else {
                throw new ArgumentException($"Invalid {nameof(grade)} value. {nameof(grade)} should be between 0 and 100.");
            }
            
        }

        public override Statistics GetStatistics() {
            var stats = new Statistics();

            for (int i = 0; i < Grades.Count; i++)
            {
                stats.Add(Grades[i]);
            }

            return stats;
        }

        public override string GetGradeList() {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < Grades.Count; i++)
            {
                stringBuilder.Append($"#{(i + 1).ToString()}:{(((i + 1) >= 10) ? "" : " ")} {Grades[i]} \t");
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