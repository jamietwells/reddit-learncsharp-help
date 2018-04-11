using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace project2 {
    public class CensusReader {
        private readonly string _path;
        private const string pattern = @"^\d+,[SMD],[MF],\d+$";

        public CensusReader(string path) {
            _path = path;
        }

        public CensusReader ReadFile() {
            CensusItems = GetFakeData() // You should use GetData()
                .Where(LineIsValid) // skip invalid lines
                .Select(line => new CensusItem(line)) // turn each line into an instance of a CensusItem class
                .ToArray();

            return this;
        }

        private bool LineIsValid(string line) => Regex.IsMatch(line, pattern);

        // You should read in with this method, but I'm not
        // going to use it because I don't have the file
        private string[] GetData() => File.ReadAllLines(_path);

        private string[] GetFakeData() {
            return new[] {
                "22,S,M,1",
                "45,M,M,2",
                "72,M,M,5",
                "43,D,F,12",
                "18,S,F,20",
                "36,S,M,15",
                "66,D,F,35",
                "25,S,F,5"
            };
        }

        public ICollection<CensusItem> CensusItems { get; private set; }

        public void PrintData(Action<string> printAction) {
            foreach (var data in CensusItems) {
                printAction(data.Format());
            }
        }
    }
}