using Coursera.Stanford.Implementations;
using Reflectiondm.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursera.Stanford.Week1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = FileHelper.GetArrayFromFile("IntegerArray.txt");
            var calc = new InversionCalculationImpl();
            var time1 = DateTime.Now;
            var inversionsCount = calc.Calc(input);
            var time2 = DateTime.Now;
            var interval = (time2 - time1).TotalMilliseconds;

            Console.WriteLine("Number of inversions for IntegerArray.txt = {0}", inversionsCount);
            Console.WriteLine("Operation took {0} ms to complete", interval);

            Console.ReadLine();
        }
    }
}
