using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class DepositTestData_StartEndPos : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, .999999999m, .999999999m };
            yield return new object[] { 1, .999999999m, 1.999999999m };
            yield return new object[] { 1.50, 1.495, 2.995 };
            yield return new object[] { 1.5555, 1.554, 3.1095 };
            yield return new object[] { 99.99, .99, 100.98 };
            yield return new object[] { 100, 1, 101 };
            yield return new object[] { 100, .01, 100.01 };
            yield return new object[] { 100, 20.99, 120.99 };
            yield return new object[] { 100, 20.99999, 120.99999 };
            yield return new object[] { 100, 100, 200 };
            yield return new object[] { 1000000000, .000000001, 1000000000.000000001m };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}