using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Transactions;

namespace NumberTypes
{ 
    internal class NumberTypes
    {
        public static MyMath MM = new MyMath();

        static void Main()
        {
            var NT = new NumberTypes();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Perfect numbers
            Console.WriteLine($"Perfect numbers up to 10000: {NT.PerfectNumbers(10000)}");
            Console.WriteLine($"Finding perfect numbers took {(float)stopwatch.ElapsedMilliseconds/1000} seconds\n");
            stopwatch.Reset();
            stopwatch.Start();

            // Amicable numbers
            Console.WriteLine($"Amicable numbers up to 100000: {NT.AmicableNumbers(100000)}");
            Console.WriteLine($"Amicable numbers took {(float)stopwatch.ElapsedMilliseconds / 1000} seconds\n");
            stopwatch.Reset();
            stopwatch.Start();

            // Powerful numbers
            Console.WriteLine($"Powerful numbers from 100 to 1000: {NT.PowerfulNumbers(1000)}");
            Console.WriteLine($"Powerful numbers took {(float)stopwatch.ElapsedMilliseconds / 1000} seconds\n");


            Console.ReadKey();
        }

        // A perfect number is a positive integer that is equal to the sum of its positive divisors, excluding the number itself.
        // https://en.wikipedia.org/wiki/Perfect_number
        public string PerfectNumbers(int upTo) {

            List<int> numbers = new List<int>();

            for (int i = 2; i <= upTo; i++)
            {
                if (MM.GetDivisorSum(i, true, false) == i)
                {
                    numbers.Add(i);
                }
            }

            return string.Join(", ", numbers.ToArray());
        }

        // An abundant number or excessive number is a number for which the sum of its proper divisors is greater than the number.
        // https://en.wikipedia.org/wiki/Abundant_number
        public string AbundantNumbers(int upTo)
        {
            List<int> numbers = new List<int>();

            for (int i = 2; i <= upTo; i ++)
            {
                if (MM.GetDivisorSum(i, true, false) > i)
                {
                    numbers.Add(i);
                }
            }

            return string.Join(", ", numbers.ToArray());
        }

        // Amicable numbers are two different natural numbers related in such a way that the sum of the proper divisors of each is equal to the other number.
        // https://en.wikipedia.org/wiki/Amicable_numbers
        public string AmicableNumbers(int upTo)
        {
            int divSum = 0;
            List<int> numbers = new List<int>();

            for (int i = 2; i <= upTo; i++)
            {
                divSum = MM.GetDivisorSum(i, true, false);

                // First condition filters out perfect numbers, the second eliminates duplication
                if (divSum == i || numbers.Contains(divSum)) continue;
                
                if (MM.GetDivisorSum(divSum, true, false) == i)
                {
                    numbers.Add(i);
                    numbers.Add(divSum);
                }
            }

            return string.Join(", ", numbers.ToArray());
        }

        // A powerful number is a positive integer m such that for every prime number p dividing m, p2 also divides m.
        // https://en.wikipedia.org/wiki/Powerful_number
        public string PowerfulNumbers(int upTo)
        {
            bool allPrimeSquaresDivide;
            List<int> divs = new List<int>();
            List<int> primeDivs = new List<int>();
            List<int> numbers = new List<int>();

            for (int i = 100; i <= upTo; i++)
            {
                if (MM.IsPrime(i)) continue;

                allPrimeSquaresDivide = true;
                divs = MM.GetDivisors(i, true, true);
                primeDivs = divs.Where(x => MM.IsPrime(x)).ToList();

                foreach (int num in primeDivs)
                {
                    if (i % (num * num) == 0) continue;

                    // If the square of ANY of the prime divisors does not divide 'i',
                    // the conditions for a powerful number are not satisfied.
                    else
                    {
                        allPrimeSquaresDivide = false;
                        break;
                    }
                }

                if (allPrimeSquaresDivide) {
                    numbers.Add(i);
                }
            }

            return string.Join(", ", numbers.ToArray());
        }
    }
}