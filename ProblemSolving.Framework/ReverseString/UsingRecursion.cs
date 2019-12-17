using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.Framework.ArrayMerge
{
    public class UsingRecursion
    {
        public class Solution
        {
            public string solution(string input)
            {
                string result = ReverseString(input);

                return result;
            }

            public string ReverseString(string input)
            {
                if (string.IsNullOrEmpty(input))
                    return string.Empty;

                return input[input.Length - 1] + ReverseString(input.Substring(0, input.Length - 1));
            }
        }
    }
}
