namespace ProblemSolving.Framework.ArrayMerge
{
    public class UnsortedArray
    {
        public class Solution
        {
            public int[] solution(int[] A, int[] B)
            {
                //1, 1, 1, 1, 1
                //2, 2, 2
                int[] result = new int[A.Length + B.Length];

                for (int i = 0, j = 0; i < A.Length || i < B.Length; i++)
                {
                    if (i < A.Length)
                    {
                        result[j] = A[i];
                        j++;
                    }

                    if (i < B.Length)
                    {
                        result[j] = B[i];
                        j++;
                    }
                }

                return result;
            }
        }
    }
}
