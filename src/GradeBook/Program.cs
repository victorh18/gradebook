using System;

namespace GradeBook {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Executing Grading App...");

            if (args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]}");
            } else {
                Console.WriteLine("Hello User!");
            }
        }
    }
}