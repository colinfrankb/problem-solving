using System;
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

            return string.Join(" ", weights);
        }
    }
}
