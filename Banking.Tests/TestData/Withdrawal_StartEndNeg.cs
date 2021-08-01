using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class Withdrawal_StartEndNeg : IEnumerable<object[]>
    {
        public static List<object[]> TestData = new List<object[]>
        {
            new object[] { -1m, .9999999m, -1.9999999m,},
            new object[] { -1.50m, 1.495m, -2.995m,},
            new object[] { -1.5555m, 1.554m, -3.1095m,},
            new object[] { -99.99m, .99m, -100.98m,},
            new object[] { -100m, 1m, -101m,},
            new object[] { -100m, .01m, -100.01m,},
            new object[] { -100m, 20.99m, -120.99m,},
            new object[] { -100m, 20.99999m, -120.99999m,},
            new object[] { -100m, 100m, -200m,},
            new object[] { -1000000000m, .000000001m, -1000000000.000000001m },
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