using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class WithdrawalTestData_InvalidValues : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100, 0 };
            yield return new object[] { 100, -1 };
            yield return new object[] { 100, -1000 };
            yield return new object[] { 100, -10000000 };
            yield return new object[] { 0, -1.999999 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}