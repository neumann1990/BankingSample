using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class Withdrawal_StartEndPos : IEnumerable<object[]>
    {
        public static List<object[]> TestData = new List<object[]>
        {
            new object[] { 1m, .999999999m, .000000001m },
            new object[] { 1.50m, 1.495m, .005m,},
            new object[] { 1.5555m, 1.5554m, .0001m,},
            new object[] { 99.99m, .99m, 99m,},
            new object[] { 100m, 1m, 99m,},
            new object[] { 100m, .01m, 99.99m,},
            new object[] { 100m, 20.99m, 79.01m,},
            new object[] { 100m, 20.99999m, 79.00001m,},
            new object[] { 100m, 100m, 0m,},
            new object[] { 1000000000m, .000000001m, 999999999.999999999m },
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var testCase in TestData)
            {
                yield return testCase;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}