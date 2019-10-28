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

                for (int i = 0, Ai = 0, Bi = 0; Ai < A.Length || Bi < B.Length; i++)
                {
                    if (Ai < A.Length && Bi < B.Length)
                    {
                        if (A[Ai] <= B[Bi])
                        {
                            result[i] = A[Ai];
                            Ai++;
                        }
                        else
                        {
                            result[i] = B[Bi];
                            Bi++;
                        }
                    }
                    else
                    {
                        if (Ai < A.Length)
                        {
                            result[i] = A[Ai];
                            Ai++;
                        }
                        else // Bi < B.Length
                        {
                            result[i] = B[Bi];
                            Bi++;
                        }
                    }
                }

                return result;
            }
        }
    }
}
