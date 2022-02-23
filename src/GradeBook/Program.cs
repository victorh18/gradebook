namespace GradeBook {
    class Program {
        static void Main(string[] args) {
            var book = new Book("Science's Grade Book");

            book.AddGrade(12.7);
            book.AddGrade(10.3);
            book.AddGrade(6.11);
            book.AddGrade(4.1);

            Book.Greet(args[0]);
            
            book.ShowStats();

            return;
        }
    }
}