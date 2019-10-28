using NUnit.Framework;
using ProblemSolving.Framework.ArrayMerge;

namespace ProblemSolving.Tests.ArrayMerge
{
    [TestFixture]
    public class SortedArrayTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 3, 5, 7, 9 }, new int[] { 2, 4, 6, 8, 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4 }, new int[] { 5, 6 })]
        public void ReturnsSortedMergedArray(int[] expected, int[] A, int[] B)
        {
            var solution = new SortedArray.Solution();

            Assert.AreEqual(expected, solution.solution(A, B));
        }
    }
}