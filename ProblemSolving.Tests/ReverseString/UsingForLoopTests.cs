using NUnit.Framework;
using ProblemSolving.Framework.ArrayMerge;

namespace ProblemSolving.Tests.ArrayMerge
{
    [TestFixture]
    public class UsingForLoopTests
    {
        [TestCase("mlkjihgfedcba", "abcdefghijklm")]
        [TestCase("ba", "ab")]
        public void ReturnsReversedString(string expected, string input)
        {
            var solution = new UsingForLoop.Solution();

            Assert.AreEqual(expected, solution.solution(input));
        }
    }
}