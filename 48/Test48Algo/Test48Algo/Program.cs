using System;
using System.Collections.Generic;
using System.Linq;

using System.Numerics; // специальная бибилитека для больших чисел
using System.Text;
using System.Threading.Tasks;

namespace Test48Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger sum=0;
            for (int i = 1; i <= 1000; i++)
            {
                sum += BigInteger.Pow(i, i);
            }
            string s = sum.ToString();
            Console.WriteLine(s.Substring(s.Length-10,10));
            Console.ReadKey();
        }
    }
}
