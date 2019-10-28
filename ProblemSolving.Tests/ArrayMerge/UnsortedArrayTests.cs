using NUnit.Framework;
using ProblemSolving.Framework.ArrayMerge;

namespace ProblemSolving.Tests.ArrayMerge
{
    [TestFixture]
    public class UnsortedArrayTests
    {
        [TestCase(new int[] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 2, 2, 2, 2, 2 })]
        [TestCase(new int[] { 1, 2, 1, 2, 1, 2, 1, 1 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 2, 2, 2 })]
        public void ReturnsMergedArray(int[] expected, int[] A, int[] B)
        {
            var solution = new UnsortedArray.Solution();

            Assert.AreEqual(expected, solution.solution(A, B));
        }
    }
}