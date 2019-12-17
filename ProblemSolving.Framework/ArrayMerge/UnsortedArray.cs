namespace ProblemSolving.Framework.ArrayMerge
{
    public class UnsortedArray
    {
        public class Solution
        {
            public int[] solution(int[] A, int[] B)
            {
                // 1, 1, 1, 1
                // 2, 2

                int[] result = new int[A.Length + B.Length];

                for (int i = 0, j = 0; i < result.Length; j++)
                {
                    if (j < A.Length)
                    {
                        result[i] = A[j];
                        i++;
                    }

                    if (j < B.Length)
                    {
                        result[i] = B[j];
                        i++;
                    }
                }

                return result;
            }
        }
    }
}
