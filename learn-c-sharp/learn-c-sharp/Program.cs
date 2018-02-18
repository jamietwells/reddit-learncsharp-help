using System;

namespace LearnCSharp {

    class Program {

        static void Main(string[] args) {
            PrintIntroduction();

            Console.WriteLine("Please enter a MIN value:");
            int MIN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter a MAX value:");
            int MAX = Convert.ToInt32(Console.ReadLine());


            PrintNumbersBetween(MIN, MAX);

            Pause();
        }

        private static void PrintNumbersBetween(int MIN, int MAX) {

            for (int x = MIN; x <= MAX; x++)
            {
                Console.WriteLine(x.ToString());
            }
        }
        private static void Pause() => Console.ReadKey();
      
    private static void PrintIntroduction() {
            Console.WriteLine("=====================================");
            Console.WriteLine("Prime Factorisation");
            Console.WriteLine("=====================================");
            
        }
    }
}
