using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class Transfer_StartNegEndPos : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { -1m, 1.999999999m, .999999999m };
            yield return new object[] { -1.50m, 1.505m, .005m,};
            yield return new object[] { -1.5555m, 1.5556m, .0001m,};
            yield return new object[] { -99.99m, 199.99m, 100m,};
            yield return new object[] { -100m, 100.000000001m, .000000001m,};
            yield return new object[] { -100m, 200.01m, 100.01m,};
            yield return new object[] { -100m, 120.99m, 20.99m,};
            yield return new object[] { -100m, 120.987654321m, 20.987654321m,};
            yield return new object[] { -100m, 106.975m, 6.975m,};
            yield return new object[] { -1000000000m, 2000000000.000000001m, 1000000000.000000001m };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}