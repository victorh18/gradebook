namespace GradeBook {
    class Program {
        static void Main(string[] args) {
            var book = new Book("Science's Grade Book");

            book.AddGrade(12.7);
            book.AddGrade(10.3);
            book.AddGrade(6.11);
            book.AddGrade(4.1);

            Book.Greet(args[0]);

            var stats = book.GetStatistics();

            Console.WriteLine("After evaluating the following grades:");
            System.Console.WriteLine(book.GetGradeList());
            System.Console.WriteLine();
            System.Console.WriteLine($"The average is: {stats.Average.ToString("##0.00")}");
            System.Console.WriteLine($"The highest grade is: {stats.Max.ToString("##0.00")}");
            System.Console.WriteLine($"The lowest grade is: {stats.Min.ToString("##0.00")}");

            return;
        }
    }
}