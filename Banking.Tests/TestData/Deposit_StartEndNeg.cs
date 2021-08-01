using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class Deposit_StartEndNeg : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { -1m, .999999999m, -.000000001m };
            yield return new object[] { -1.50m, 1.495m, -.005m,};
            yield return new object[] { -1.5555m, 1.5554m, -.0001m,};
            yield return new object[] { -99.99m, .99m, -99m,};
            yield return new object[] { -100m, 1m, -99m,};
            yield return new object[] { -100m, .01m, -99.99m,};
            yield return new object[] { -100m, 20.99m, -79.01m,};
            yield return new object[] { -100m, 20.99999m, -79.00001m,};
            yield return new object[] { -100m, 100m, -0m,};
            yield return new object[] { -1000000000m, .000000001m, -999999999.999999999m };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}