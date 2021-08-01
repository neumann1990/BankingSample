using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class Deposit_InvalidValues : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100m, 0m,};
            yield return new object[] { 100m, -1m,};
            yield return new object[] { 100m, -1000m,};
            yield return new object[] { 100m, -10000000m,};
            yield return new object[] { 0m, -1.999999m,};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}