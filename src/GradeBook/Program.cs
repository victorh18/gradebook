namespace GradeBook {
    class Program {
        static void Main(string[] args)
        {
            var username = args[0];
            IBook book = new DiskBook($"{username}'s Grade Book");
            book.GradeAdded += OnGradeAdded;

            InMemoryBook.Greet(username);
            System.Console.WriteLine("Please, enter the grades you want to register followed by ENTER. Enter Q to calculate the results and exit the application.");

            EnterGrades(book);

            var stats = book.GetStatistics();

            System.Console.WriteLine();
            Console.WriteLine("After evaluating the following grades:");
            System.Console.WriteLine(book.GetGradeList());
            System.Console.WriteLine();
            System.Console.WriteLine($"The average is: {stats.Average.ToString("##0.00")} ({stats.Letter})");
            System.Console.WriteLine($"The highest grade is: {stats.Max.ToString("##0.00")}");
            System.Console.WriteLine($"The lowest grade is: {stats.Min.ToString("##0.00")}");

            return;
        }

        private static void EnterGrades(IBook book)
        {
            string? input = "";
            int gradeNumber = 1;

            while (input?.ToUpper() != "Q")
            {
                System.Console.Write($"Grade #{gradeNumber}: ");
                input = Console.ReadLine();
                double grade = 0;

                try
                {
                    if (double.TryParse(input, out grade))
                    {
                        book.AddGrade(grade);
                        gradeNumber++;
                    }
                    else if (input?.ToUpper() != "Q")
                    {
                        throw new ArgumentException($"Invalid {nameof(grade)}. Only numeric values are accepted at the moment.");
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            System.Console.WriteLine("[LOG] \tA grade was added.");
        }
    }
}