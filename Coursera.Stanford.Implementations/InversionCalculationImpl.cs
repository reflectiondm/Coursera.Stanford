using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursera.Stanford.Implementations
{
    public class InversionCalculationImpl
    {
        public int Calc(long[] input)
        {
            var result = CountAndSort(input);
            return result.Count;
        }

        internal IntermediateResult CountAndSort(long[] input)
        {
            var result = new IntermediateResult();
            //trivial case
            if (input.Length == 1)
                result.Count = 0;
            else
            {
                var parts = Split(input);
                var leftResult = CountAndSort(parts.Item1);
                var rightResult = CountAndSort(parts.Item2);
                var split = CountSplitInv(leftResult.IntermediateArray, rightResult.IntermediateArray);

                result.Count = leftResult.Count + rightResult.Count + split.Count;
            }

            return result;
        }

        private IntermediateResult CountSplitInv(long[] left, long[] right)
        {
            throw new NotImplementedException();
        }

        private Tuple<long[], long[]> Split(long[] input)
        {
            throw new NotImplementedException();
        }
    }

    internal class IntermediateResult
    {
        public int Count { get; set; }
        public long[] IntermediateArray { get; set; }
    }
}