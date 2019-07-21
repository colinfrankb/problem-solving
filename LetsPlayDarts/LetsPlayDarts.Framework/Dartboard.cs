using System;

namespace LetsPlayDarts.Framework
{
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

            if (circle == 6.35)
            {
                return "DB";
            }

            if (circle == 15.9)
            {
                return "SB";
            }

            double score = CalculateRelativeScore(x, y);
            string multiplier = DetermineMultiplier(circle);

            return $"{multiplier}{score}";
        }

        private string DetermineMultiplier(double? circle)
        {
            if (circle == 107)
                return "T";

            if (circle == 170)
                return "D";

            return string.Empty;
        }

        private double CalculateRelativeScore(double x, double y)
        {
            double angle = CalculateAngleInDegrees(x, y);
            ScoreMap scoreMap = new ScoreMap();

            if (x > 0 && y > 0) // 1st quadrant
            {
                return scoreMap.DetermineScoreInFirstQuadrant(angle);
            }

            if (x < 0 && y > 0) // 2nd quandrant
            {
                return scoreMap.DetermineScoreInSecondQuadrant(angle);
            }

            if (x < 0 && y < 0) // 3rd quadrant
            {
                return scoreMap.DetermineScoreInThirdQuadrant(angle);
            }

            // therefore 4th quadrant
            return scoreMap.DetermineScoreInFourthQuadrant(angle);

        }

        private double CalculateAngleInDegrees(double x, double y)
        {
            return Math.Atan(y / x);
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

        private class ScoreMap
        {
            public double DetermineScoreInFirstQuadrant(double angle)
            {
                if (IsWithin(angle, 82, 90))
                    return 20;
                if (IsWithin(angle, 64, 81))
                    return 1;
                if (IsWithin(angle, 46, 63))
                    return 18;
                if (IsWithin(angle, 28, 45))
                    return 4;
                if (IsWithin(angle, 10, 27))
                    return 13;
                if (IsWithin(angle, 0, 9))
                    return 6;

                throw new ArgumentOutOfRangeException();
            }

            public double DetermineScoreInSecondQuadrant(double angle)
            {
                if (IsWithin(angle, 82, 90))
                    return 20;
                if (IsWithin(angle, 64, 81))
                    return 5;
                if (IsWithin(angle, 46, 63))
                    return 12;
                if (IsWithin(angle, 28, 45))
                    return 9;
                if (IsWithin(angle, 10, 27))
                    return 14;
                if (IsWithin(angle, 0, 9))
                    return 11;

                throw new ArgumentOutOfRangeException();
            }

            public double DetermineScoreInThirdQuadrant(double angle)
            {
                if (IsWithin(angle, 82, 90))
                    return 3;
                if (IsWithin(angle, 64, 81))
                    return 19;
                if (IsWithin(angle, 46, 63))
                    return 7;
                if (IsWithin(angle, 28, 45))
                    return 16;
                if (IsWithin(angle, 10, 27))
                    return 8;
                if (IsWithin(angle, 0, 9))
                    return 11;

                throw new ArgumentOutOfRangeException();
            }

            public double DetermineScoreInFourthQuadrant(double angle)
            {
                if (IsWithin(angle, 82, 90))
                    return 3;
                if (IsWithin(angle, 64, 81))
                    return 17;
                if (IsWithin(angle, 46, 63))
                    return 7;
                if (IsWithin(angle, 28, 45))
                    return 15;
                if (IsWithin(angle, 10, 27))
                    return 10;
                if (IsWithin(angle, 0, 9))
                    return 6;

                throw new ArgumentOutOfRangeException();
            }

            private bool IsWithin(double angle, double start, double end)
            {
                return angle >= start && angle <= end;
            }
        }
    }
}
