using System;

namespace OddArray.Framework
{
    public class Solution
    {
        //Codility detected time complexity O(N) or O(N*log(N))
        public int solution(int[] A)
        {
            Array.Sort(A);

            for (int i = 0, j = 1; j < A.Length; i += 2, j += 2)
            {
                if (A[i] != A[j])
                {
                    return A[i];
                }
            }

            return A[A.Length - 1];
        }

        public int[] Sort(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[j] > A[i])
                    {
                        int temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;
                    }
                }
            }

            return A;
        }
    }
}
