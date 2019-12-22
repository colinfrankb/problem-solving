using NUnit.Framework;
using ProblemSolving.Framework.ArrayMerge;

namespace ProblemSolving.Tests.ReverseString
{
    [TestFixture]
    public class UsingRecursionTests
    {
        [TestCase("mlkjihgfedcba", "abcdefghijklm")]
        [TestCase("ba", "ab")]
        public void ReturnsReversedString(string expected, string input)
        {
            var solution = new UsingRecursion.Solution();

            Assert.AreEqual(expected, solution.solution(input));
        }
    }
}