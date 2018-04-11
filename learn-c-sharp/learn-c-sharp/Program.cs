using System;

namespace project2 {
    public class Program {
        public static void Main(string[] args) {
            new CensusReader("census.txt")
                .ReadFile()
                .PrintData(Console.WriteLine);
        }
    }
}