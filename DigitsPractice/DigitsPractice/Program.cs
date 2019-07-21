using System;

namespace DigitsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"DigPow(89, 1) = {Algorithm.DigPow(89, 1)} (1)");
            Console.WriteLine($"DigPow(92, 1) = {Algorithm.DigPow(92, 1)} (-1)");
            Console.WriteLine($"DigPow(695, 2) = {Algorithm.DigPow(695, 2)} (2)");
            Console.WriteLine($"DigPow(46288, 3) = {Algorithm.DigPow(46288, 3)} (51)");


            Console.ReadLine();
        }
    }

    public class Algorithm
    {
        public static long DigPow(int n, int p)
        {
            var digits = n.ToString();
            var summation = 0D;

            for (int i = 0; i < digits.Length; i++, p++)
            {
                summation += Math.Pow(char.GetNumericValue(digits[i]), p);
            }

            Console.WriteLine(summation);

            return (long)(summation % n == 0 ? summation / n : -1);
        }
    }
}
