using System;

namespace LearnCSharp {

    class Program {

        static void Main(string[] args) {
            PrintIntroduction();

            Console.WriteLine("Please enter a MIN value:");
            int MIN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter a MAX value:");
            int MAX = Convert.ToInt32(Console.ReadLine());

            Pause();
        }

        private static void Pause() => Console.ReadKey();

        private static void PrintIntroduction() {
            Console.WriteLine("=====================================");
            Console.WriteLine("Prime Factorisation");
            Console.WriteLine("=====================================");
        }
    }
}
