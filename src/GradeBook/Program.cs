namespace GradeBook {
    class Program {
        static void Main(string[] args) {
            if (args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]}");
            } else {
                Console.WriteLine("Hello User!");
            }

            List<double> grades = new List<double>() {12.7, 10.3, 6.11, 4.1};

            var result = 0.0;

            foreach(var number in grades) {
                result += number;
            }
            
            result /= grades.Count();

            var gradeList = string.Join(", ", grades);

            Console.WriteLine("After evaluating the results of the following grades:");
            System.Console.WriteLine(gradeList);
            System.Console.WriteLine();
            System.Console.WriteLine($"The average is: {result.ToString("##0.00")}");
            System.Console.WriteLine($"The highest grade is: {grades.Max().ToString("##0.00")}");
            System.Console.WriteLine($"The lowest grade is: {grades.Min().ToString("##0.00")}");

            return;
        }
    }
}