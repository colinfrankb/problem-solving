using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving.Framework.ArrayMerge
{
    public class SortedArray
    {
        public class Solution
        {
            //Axioms
            //A and B can be variable lengths
            public int[] solution(int[] A, int[] B)
            {
                //1, 3, 5, 7, 9
                //2, 4, 6, 8, 10

                //1, 2, 3, 4, 
                //5, 6
                int[] result = new int[A.Length + B.Length];

                for (int i = 0, j = 0, k = 0; i < result.Length;)
                {
                    if (j < A.Length && k < B.Length)
                    {
                        if (A[j] < B[k])
                        {
                            result[i] = A[j];
                            j++;
                        }
                        else
                        {
                            result[i] = B[k];
                            k++;
                        }

                        i++;
                    }
                    else
                    {
                        if (j < A.Length)
                        {
                            result[i] = A[j];
                            i++;
                            j++;
                        }

                        if (k < B.Length)
                        {
                            result[i] = B[k];
                            i++;
                            k++;
                        }
                    }
                }

                return result;
            }
        }
    }
}
