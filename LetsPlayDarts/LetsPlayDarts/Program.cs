using LetsPlayDarts.Framework;
using System;

namespace LetsPlayDarts
{
    class Program
    {
        static void Main(string[] args)
        {
            var dartboard = new Dartboard();

            Console.WriteLine(dartboard.GetScore(50, 30));
            Console.WriteLine(dartboard.GetScore(170, 85));
            Console.WriteLine(dartboard.GetScore(100, 20));
            Console.WriteLine(dartboard.GetScore(78, 42));
            Console.WriteLine(dartboard.GetScore(120, 46));
        }
    }
}
