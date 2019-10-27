using NUnit.Framework;
using ProblemSolving.Framework.ArrayMerge;

namespace ProblemSolving.Tests.ArrayMerge
{
    [TestFixture]
    public class SortedArrayTests
    {
        [TestCase(new int[] { 9, 3, 9, 3, 9, 7, 9 }, new int[] { 9, 3, 9, 3, 9, 7, 9 }, new int[] { 9, 3, 9, 3, 9, 7, 9 })]
        public void ReturnsOddNumberValue(int[] expected, int[] A, int[] B)
        {
            var solution = new SortedArray.Solution();

            Assert.AreEqual(expected, solution.solution(A, B));
        }
    }
}