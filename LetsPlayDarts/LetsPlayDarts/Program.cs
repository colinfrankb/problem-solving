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

    public class Dartboard
    {
        //Possible scores are:
        //Outside of the board: `"X"`
        //Bull's eye: `"DB"`
        //Bull: `"SB"`
        //A single number, example: `"10"`
        //A triple number: `"T10"`
        //A double number: `"D10"`

        //The diameters of the circles on the dartboard are:
        //Bull's eye: `12.70 mm`
        //Bull: `31.8 mm`
        //Triple ring inner circle: `198 mm`
        //Triple ring outer circle: `214 mm`
        //Double ring inner circle: `324 mm`
        //Double ring outer circle: `340 mm`

        double[] _circleRadi = new double[6] 
        {
            6.35,
            15.9,
            99,
            107,
            162,
            170
        };

        /// <summary>
        /// Determine the score
        /// </summary>
        /// <param name="x">unit(s) in mm</param>
        /// <param name="y">unit(s) in mm</param>
        /// <returns></returns>
        public string GetScore(double x, double y)
        {
            double distanceFromCenter = CalculateDistanceFromCenter(x, y);
            double? circle = CalculateWhichCircle(distanceFromCenter);

            if (circle == null)
            {
                return "X";
            }

            return $"{circle}";
        }

        private double CalculateDistanceFromCenter(double x, double y)
        {
            //Using pythagoras to determine the distance between two points
            //on a plane. In this case, the other point is the center (0, 0)
            //x^2 + y^2 = r^2

            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        private double? CalculateWhichCircle(double distanceFromCenter)
        {
            for (int i = 0; i < _circleRadi.Length; i++)
            {
                //A throw that ends exactly on the border of two sections results in a bounce out. 
                //You can ignore this because all the given coordinates of the tests are within the sections.
                //Therefore I will use a < and not <=
                if (distanceFromCenter < _circleRadi[i])
                {
                    return _circleRadi[i];
                }
            }

            return null;
        }
    }
}
