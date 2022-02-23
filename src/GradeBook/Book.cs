namespace GradeBook {
    class Book {
        List<double> grades;
        string name;

        public Book(string name)
        {
            this.name = name;
            grades = new List<double>();
        }
        public void AddGrade(double grade) {
            grades.Add(grade);
        }

        public void ShowStats() {
            var result = 0.0;

            foreach(var number in grades) {
                result += number;
            }
            
            result /= grades.Count();

            var gradeList = string.Join(", ", grades);

            Console.WriteLine("After evaluating the following grades:");
            System.Console.WriteLine(gradeList);
            System.Console.WriteLine();
            System.Console.WriteLine($"The average is: {result.ToString("##0.00")}");
            System.Console.WriteLine($"The highest grade is: {grades.Max().ToString("##0.00")}");
            System.Console.WriteLine($"The lowest grade is: {grades.Min().ToString("##0.00")}");
        }

        public static void Greet(string name)
        {
            System.Console.WriteLine($"Welcome to the grading report application, {name}!");
        }
    }
}