using NUnit.Framework;
using OddArray.Framework;
using System.Linq;

namespace OddArray.Tests
{
    [TestFixture]
    public class SolutionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(7, new int[] { 9, 3, 9, 3, 9, 7, 9 })]
        [TestCase(5, new int[] { 4, 4, 1, 1, 5 })]
        public void ReturnsOddNumberValue(int expected, int[] A)
        {
            var solution = new Solution();

            Assert.AreEqual(expected, solution.solution(A));
        }

        [Test]
        public void UpperBoundLimit()
        {
            var solution = new Solution();

            int[] A = Enumerable.Repeat(1000000000, 999998).Append(1).ToArray();

            Assert.AreEqual(1, solution.solution(A));
        }
    }
}