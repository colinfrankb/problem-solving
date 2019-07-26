using BinaryGap.Framework;
using NUnit.Framework;

namespace BinaryGap.Tests
{
    [TestFixture]
    public class SolutionTests
    {
        [TestCase(4, 529)]
        [TestCase(1, 20)]
        [TestCase(0, 15)]
        [TestCase(0, 32)]
        [TestCase(5, 1041)]
        [TestCase(0, 1)]
        [TestCase(3, 561892)]
        [TestCase(4, 74901729)]
        [TestCase(5, 1376796946)]
        [TestCase(0, 2147483647)]
        public void ReturnsLongestBinaryGap(int expected, int N)
        {
            var solution = new Solution();

            Assert.AreEqual(expected, solution.solution(N));
        }
    }
}