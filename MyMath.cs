using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTypes
{
    internal class MyMath
    {
        /// <summary>
        ///     Set <i>proper</i> to <b>true</b> if you wish to exclude the number itself from the returned array.<br/>
        ///     Set <i>exlude_1</i> to <b>true</b> if you wish to exclude 1 from the returned array.<br/>
        ///     Set <i>sort</i> to <b>true</b> if you wish to sort the array ascendingly, or to <b>false</b> if you wish to sort it descendingly.<br/>
        ///     If left unspecified or set to <b>null</b>, the array will be unchanged.
        /// </summary>
        /// <returns>Integer array of divisors of the passed number.</returns>
        public List<int> GetDivisors(int num, bool proper = false, bool exclude_1 = false, bool? sort = null)
        {
            List<int> divisors = new List<int>();

            if (!exclude_1)
            {
                divisors.Add(1);
            }

            for (int i = 2; i <= Math.Floor(Math.Sqrt(num)); i++)
            {
                if (num % i == 0)
                {
                    divisors.Add(i);

                    if (i != (num / i))
                    {
                        divisors.Add(num / i);
                    }
                }
            }

            if (!proper)
            {
                divisors.Add(num);
            }

            if (sort != null)
            {
                if (sort == true)
                {
                    divisors.Sort();
                } else {
                    divisors.Sort();
                    divisors.Reverse();
                }
            }

            return divisors;
        }

        /// <summary>
        ///     Set <i>proper</i> to <b>true</b> if you wish to exclude the number itself from the sum of its divisors.<br/>
        ///     Set <i>exlude_1</i> to <b>true</b> if you wish to exclude it from the sum of divisors.<br/>
        /// </summary>
        /// <returns>Sum of divisors of passed number.</returns>
        public int GetDivisorSum(int num, bool proper = false, bool exclude_1 = false)
        {
            int sum = 0;
            List<int> divisors = GetDivisors(num, proper, exclude_1);
            divisors.ForEach(i => sum += i);

            return sum;
        }

        /// <returns>Sum of array elements.</returns>
        public int GetArraySum(List<int> divisors)
        {
            int sum = 0;
            divisors.ForEach(i => sum += i);

            return sum;
        }

        /// <returns>Number of proper divisors of passed number, excluding 1.</returns>
        public int GetDivisorCount (int num)
        {
            return GetDivisors(num, true, true).Count;
        }
        
        /// <returns>Returns boolean indicating whether the passed number is a prime number.</returns>
        public bool IsPrime(int num)
        {
            if (num == 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            if (GetDivisorCount(num) == 0) return true;
            else return false;
        }

        /// <returns>
        ///     Returns boolean indicating whether the passed numbers are coprime.<br/>
        ///     <b><i><a href="https://en.wikipedia.org/wiki/Coprime_integers"></a></i></b>
        /// </returns>
        public bool AreCoprime(int a, int b) {
            List<int> divsA = GetDivisors(a, true, true);
            List<int> divsB = GetDivisors(b, true, true);
                     
            return !divsA.Intersect(divsB).Any();
        }
    }
}
