namespace project2 {
    public class CensusItem {

        public CensusItem(string line) {
            var data = line.Split(',');
            Age = ParseAge(data[0]);
            MaritalStatus = ParseMaritalStatus(data[1]);
            Gender = ParseGender(data[2]);
            District = ParseDistrict(data[3]);
        }

        public int Age { get; }
        public MaritalStatus MaritalStatus { get; }
        public Gender Gender { get; }
        public int District { get; }

        public int ParseAge(string s) => int.Parse(s);

        public MaritalStatus ParseMaritalStatus(string s) {
            switch (s) {
                case ("S"):
                    return MaritalStatus.Single;
                case ("M"):
                    return MaritalStatus.Married;
                case ("D"):
                    return MaritalStatus.Divorced;
                default:
                    return MaritalStatus.Unknown;
            }
        }

        public Gender ParseGender(string s) {
            switch (s) {
                case ("M"):
                    return Gender.Male;
                case ("F"):
                    return Gender.Female;
                default:
                    return Gender.Unknown;
            }
        }

        public int ParseDistrict(string s) => int.Parse(s);

        public string Format() => $"Age: {Age}, Marital Status: {MaritalStatus}, Gender: {Gender}, District: {District}";
    }
}