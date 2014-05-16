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
            {
                result.Count = 0;
                result.IntermediateArray = input;
            }
            else
            {
                var parts = Split(input);
                var leftResult = CountAndSort(parts.Item1);
                var rightResult = CountAndSort(parts.Item2);
                var split = CountSplitInv(leftResult.IntermediateArray, rightResult.IntermediateArray);

                result.Count = leftResult.Count + rightResult.Count + split.Count;
                result.IntermediateArray = split.IntermediateArray;
            }

            return result;
        }

        public IntermediateResult CountSplitInv(long[] left, long[] right)
        {
            var result = new IntermediateResult();
            result.IntermediateArray = new long[left.Length + right.Length];
            var resArr = result.IntermediateArray;
            var i = 0;
            var j = 0;

            for (int k = 0; k < resArr.Length; k++)
            {
                if (i == left.Length)
                {
                    resArr[k] = right[j];
                    break;
                }
                if (j == right.Length)
                {
                    resArr[k] = left[i];
                    break;
                }


                if (left[i] < right[j])
                {
                    resArr[k] = left[i];
                    i++;
                }
                else
                {
                    resArr[k] = right[j];
                    result.Count += left.Length - i;
                    j++;
                }
            }
            return result;
        }

        public Tuple<long[], long[]> Split(long[] input)
        {
            var rightLength = 0;
            var leftLength = 0;
            rightLength = input.Length / 2;

            leftLength = (input.Length % 2) != 0 ?
                rightLength + 1 :
                rightLength;

            var halfLenght = input.Length / 2;
            return new Tuple<long[], long[]>(
                input.Take(leftLength).ToArray(),
                input.Skip(leftLength).ToArray());
        }
    }

    public class IntermediateResult
    {
        public int Count { get; set; }
        public long[] IntermediateArray { get; set; }
    }
}