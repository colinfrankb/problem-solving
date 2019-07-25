using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WeightForWeight.Framework
{
    public class WeightSort
    {
        public static string orderWeight(string strng)
        {
            string[] weights = Regex.Split(strng, @"\s+")
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();

            for (int i = 0; i < weights.Length; i++)
            {
                for (int n = i + 1; n < weights.Length; n++)
                {
                    if (SumOfDigit(weights[n]) < SumOfDigit(weights[i]))
                    {
                        string a = weights[i];
                        weights[i] = weights[n];
                        weights[n] = a;
                    }
                    else if (SumOfDigit(weights[n]) == SumOfDigit(weights[i]))
                    {
                        var list = new List<string>() { weights[i], weights[n] };

                        list.Sort();

                        weights[i] = list[0];
                        weights[n] = list[1];
                    }
                }
            }

            return string.Join(" ", weights);
        }

        private static double SumOfDigit(string value)
        {
            return value.Sum(c => char.GetNumericValue(c));
        }
    }
}
