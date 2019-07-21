using System;

namespace Tribonacci.Framework
{
    public class Xbonacci
    {
        public double[] Tribonacci(double[] signature, int n)
        {
            if (n == 0)
            {
                return new double[] { };
            }

            double[] result = new double[n];
            if( n > 0)
                result[0] = signature[0];

            if (n > 1)
                result[1] = signature[1];

            if (n > 2)
                result[2] = signature[2];

            for (int i = 3; i < n; i++)
            {
                result[i] = result[i-1] + result[i-2] + result[i-3];
            }

            return result;
        }
    }
}
