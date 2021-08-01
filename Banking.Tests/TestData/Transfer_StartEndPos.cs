using System.Collections;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class Transfer_StartEndPos : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0m, .999999999m, .999999999m };
            yield return new object[] { 1m, .999999999m, 1.999999999m };
            yield return new object[] { 1.50m, 1.495m, 2.995m,};
            yield return new object[] { 1.5555m, 1.554m, 3.1095m,};
            yield return new object[] { 99.99m, .99m, 100.98m,};
            yield return new object[] { 100m, 1m, 101m,};
            yield return new object[] { 100m, .01m, 100.01m,};
            yield return new object[] { 100m, 20.99m, 120.99m,};
            yield return new object[] { 100m, 20.99999m, 120.99999m,};
            yield return new object[] { 100m, 100m, 200m,};
            yield return new object[] { 1000000000m, .000000001m, 1000000000.000000001m };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}