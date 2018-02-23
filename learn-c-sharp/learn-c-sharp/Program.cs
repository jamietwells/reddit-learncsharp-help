using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnCSharp {

    class Program {

        static void Main(string[] args) {
            Console.WriteLine("=====================================");
            Console.WriteLine("Prime Factorisation");
            Console.WriteLine("=====================================");

            var min = UserInput.GetIntValue("Please enter the minimum value:");
            var max = UserInput.GetIntValue("Please enter the maximum value:");

            new FactorPrinter(min, max).Print();
            //new FactorPrinter(min, max).PrintForAll();

            Console.ReadKey();
        }
    }

    public class FactorPrinter {
        private readonly int _min;
        private readonly int _max;

        public FactorPrinter(int first, int second) {
            _min = Math.Min(first, second);
            _max = Math.Max(first, second);
        }

        private IEnumerable<PrimeGenerator> GetAllNumbersExceptOne() =>
             NumberGenerator.GetNumbersBetween(_min, _max)
            .Where(number => number != 1)
            .Select(number => new PrimeGenerator(number));

        private IEnumerable<PrimeGenerator> GetCompositeNumbers() => 
            GetAllNumbersExceptOne()
            .Where(number => !number.IsPrime());

        public void Print() => Print(GetCompositeNumbers());

        public void PrintForAll() => Print(GetAllNumbersExceptOne());

        private void Print(IEnumerable<PrimeGenerator> numbers) {
            foreach (var number in numbers) {
                Console.WriteLine(PrintFor(number));
            }
        }

        private string PrintFor(PrimeGenerator number) => $"{number.Input}: {string.Join(", ", number.GetPrimeFactors())}";
    }

    public class NumberGenerator {
        public static IEnumerable<int> GetNumbersBetween(int first, int last) => Enumerable.Range(first, last - first + 1);
    }

    public class PrimeGenerator {
        public int Input { get; private set; }

        public PrimeGenerator(int input) {
            Input = input;
        }

        public bool IsPrime() => IsPrime(Input);

        private IEnumerable<int> FactorsThatArePrime() =>
            new FactorsGenerator(Input)
            .GetFactors()
            .Where(IsPrime)
            .OrderByDescending(factor => factor);

        public IEnumerable<int> GetPrimeFactors() {
            var number = Input;
            foreach (var primeFactor in FactorsThatArePrime()) {
                while (number % primeFactor == 0) {
                    number = number / primeFactor;
                    yield return primeFactor;
                }
            }
        }

        private bool IsPrime(int number) => new FactorsGenerator(number).GetFactors().Count() == 2;
    }

    public class FactorsGenerator {
        private readonly int _input;

        public FactorsGenerator(int input) {
            _input = input;
        }

        public IEnumerable<int> GetFactors() =>
            NumberGenerator.GetNumbersBetween(1, _input)
            .Where(CheckIfFactorOfInput);

        private bool CheckIfFactorOfInput(int number) => _input % number == 0;
    }

    public class UserInput {

        public static int GetIntValue(string message) {
            int result;
            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out result)) {
                Console.WriteLine("Please enter an integer value only");
            }
            return result;
        }
    }

}
