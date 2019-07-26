using System;

namespace BinaryGap.Framework
{
    public class Solution
    {
        public int solution(int N)
        {
            int longestBinaryGap = 0;
            int gapCounter = 0;
            int bitCounter = 0;
            bool countingGap = false;

            while (bitCounter <= 31)
            {
                int power = (int)Math.Pow(2, bitCounter);

                if ((N & power) != 0)
                {
                    countingGap = true;

                    if (gapCounter > longestBinaryGap)
                    {
                        longestBinaryGap = gapCounter;
                    }

                    gapCounter = 0;
                }
                else
                {
                    if (countingGap)
                    {
                        gapCounter++;
                    }
                }

                bitCounter++;
            }

            return longestBinaryGap;
        }
    }
}
