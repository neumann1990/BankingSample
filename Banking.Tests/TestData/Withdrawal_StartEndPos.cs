using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class Withdrawal_StartEndPos : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, .999999999m, .000000001m };
            yield return new object[] { 1.50, 1.495, .005 };
            yield return new object[] { 1.5555, 1.5554, .0001 };
            yield return new object[] { 99.99, .99, 99 };
            yield return new object[] { 100, 1, 99 };
            yield return new object[] { 100, .01, 99.99 };
            yield return new object[] { 100, 20.99, 79.01 };
            yield return new object[] { 100, 20.99999, 79.00001 };
            yield return new object[] { 100, 100, 0 };
            yield return new object[] { 1000000000, .000000001m, 999999999.999999999m };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}