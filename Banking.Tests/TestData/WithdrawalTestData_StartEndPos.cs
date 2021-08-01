using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class WithdrawalTestData_StartEndPos : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, 9999999.99, -9999999.99 };
            yield return new object[] { 100, 9999999.99, -9999899.99 };
            yield return new object[] { 999999999, 1000000000, -1 };
            yield return new object[] { 999999999.999999999m, 1000000000, -.000000001m };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}