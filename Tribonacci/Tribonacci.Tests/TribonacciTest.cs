using NUnit.Framework;
using Tribonacci.Framework;

namespace Tests
{
    [TestFixture]
    public class TribonacciTest
    {
        [TestCase(new double[] { }, new double[] { 0, 0, 1 }, 0)]
        [TestCase(new double[] { 1, 1, 1, 3, 5, 9, 17, 31, 57, 105 }, new double[] { 1, 1, 1 }, 10)]
        [TestCase(new double[] { 0, 0, 1, 1, 2, 4, 7, 13, 24, 44 }, new double[] { 0, 0, 1 }, 10)]
        [TestCase(new double[] { 0, 1, 1, 2, 4, 7, 13, 24, 44, 81 }, new double[] { 0, 1, 1 }, 10)]
        [TestCase(new double[] { 0, 1 }, new double[] { 0, 1, 1 }, 2)]
        public void GetTribonacciSequence(double[] expected, double[] signature, int n)
        {
            var xbonacci = new Xbonacci();

            Assert.AreEqual(expected, xbonacci.Tribonacci(signature, n));
        }
    }
}