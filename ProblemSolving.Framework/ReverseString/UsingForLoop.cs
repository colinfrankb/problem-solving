using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.Framework.ArrayMerge
{
    public class UsingForLoop
    {
        public class Solution
        {
            public string solution(string input)
            {
                char[] result = input.ToCharArray();

                for (int i = 0, j = input.Length - 1; i < (input.Length / 2); i++, j--)
                {
                    char temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }

                return string.Join("", result);
            }
        }
    }
}
