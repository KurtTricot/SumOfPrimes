using System;
using System.Diagnostics;

/*
    Kurt - LordTurtle419

    Get the sum of the first 1000 primes

    Using Trial Division method

    This is the original verison, when I posted it to CodeEval I removed a lot of the filler content such as comments, Systems Diagnostics and unnecessary Console.WriteLine sections.
    This code can definitely be improved upon in terms of speed at which the calculation is done.
*/

namespace SumOfPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int countedPrimes = 0;
            int n = 0;
            int sumOfPrime = 0;

            //Test the speed of the program to compare different methods of calculation.
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (countedPrimes < 1000)
            {
                if (isPrimeNumber(n) == true)
                {
                    sumOfPrime = sumOfPrime + n;
                    Console.WriteLine("Is a Prime " + n);
                    countedPrimes++;
                }
                n++;
            }
            //Console.WriteLine(sumOfPrime);   - Used to test prime numbers were correct 
            sw.Stop();
            Console.WriteLine("Elapsed = {0}", sw.Elapsed);
            Console.ReadKey();
        }
        public static bool isPrimeNumber(float num)
        {
            bool value = false;
            if (num <= 3)
            {
                if (num == 0 || num == 1)
                {
                    value = false;
                }
                else if (num == 2 || num == 3)
                {
                    value = true;
                }
            }
            //check whether number is even
            else if (num % 2 == 0)
            {
                value = false;
            }
            else
            {
                //for (float i = 2;i < (Math.Ceiling(num)); i++) - Used this method as it was supposed to be faster than the one shown below, however after using System.Diagnostics
                //Combined with stopwatch, I found that my original method (num - 1) was measureably faster.  When testing 10000 primes, the newer method took on avg 00:00:07.7s 
                //vs older and current method of 00:00:05.4s              
                for (float i = 2; i < (num - 1); i++)
                {
                    //if (num / i) % 1 == 0, it is not a prime
                    if ((num / i) % 1 == 0)
                    {
                        value = false;
                        break;
                    }
                    else
                    {
                        value = true;
                    }
                }
            }
            return value;
        }
    }


}
