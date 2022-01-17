using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameEngine.Tests.Data
{
    public static class ExternalHealthDamageTestData
    {
        private const string Path = "Data/TestData.csv";

        public static IEnumerable<object[]> TestData
        {
            get
            {
                var csvLines = File.ReadAllLines(Path);

                var testCases = new List<object[]>();

                foreach (var csvLine in csvLines)
                {
                    IEnumerable<int> values = csvLine.Split(',').Select(int.Parse);

                    object[] testCase = values.Cast<object>().ToArray();

                    testCases.Add(testCase);
                }
                return testCases;
            }
        }
    }
}
