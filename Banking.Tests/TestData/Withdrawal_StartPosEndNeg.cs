using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class Withdrawal_StartPosEndNeg : IEnumerable<object[]>
    {
        public static List<object[]> TestData = new List<object[]>
        {
            new object[] { 1m, 1.999999999m, -.999999999m },
            new object[] { 1.50m, 1.505m, -.005m,},
            new object[] { 1.5555m, 1.5556m, -.0001m,},
            new object[] { 99.99m, 199.99m, -100m,},
            new object[] { 100m, 100.000000001m, -.000000001m,},
            new object[] { 100m, 200.01m, -100.01m,},
            new object[] { 100m, 120.99m, -20.99m,},
            new object[] { 100m, 120.987654321m, -20.987654321m,},
            new object[] { 100m, 106.975m, -6.975m,},
            new object[] { 1000000000m, 2000000000.000000001m, -1000000000.000000001m },
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