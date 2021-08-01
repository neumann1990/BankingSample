using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class Transfer_StartNegEndPos : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { -1, 1.999999999m, .999999999m };
            yield return new object[] { -1.50, 1.505, .005 };
            yield return new object[] { -1.5555, 1.5556, .0001 };
            yield return new object[] { -99.99, 199.99, 100 };
            yield return new object[] { -100, 100.000000001m, .000000001 };
            yield return new object[] { -100, 200.01, 100.01 };
            yield return new object[] { -100, 120.99, 20.99 };
            yield return new object[] { -100, 120.987654321m, 20.987654321 };
            yield return new object[] { -100, 106.975, 6.975 };
            yield return new object[] { -1000000000, 2000000000.000000001m, 1000000000.000000001m };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}