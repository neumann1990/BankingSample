using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Tests
{
    public class IndividualInvest_Withdrawal_StartPosEndNeg : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var testCase in Withdrawal_StartPosEndNeg.TestData.Where(tc => (decimal)tc[1] < 500))
            {
                yield return testCase;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}