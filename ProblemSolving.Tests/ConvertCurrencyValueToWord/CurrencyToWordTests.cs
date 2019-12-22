using NUnit.Framework;
using ProblemSolving.Framework.ConvertCurrencyValueToWord;

namespace ProblemSolving.Tests.ConvertCurrencyValueToWord
{
    [TestFixture]
    public class CurrencyToWordTests
    {
        [TestCase("Sixteen Rand", "R16")]
        [TestCase("Sixteen Rand and twenty one cents", "R16.21")]
        //[TestCase("One hundred and twenty two Rand and twenty one cents", "R122.21")]
        //[TestCase("One hundred and sixteen Rand and twenty one cents", "R116.21")]
        //[TestCase("Two hundred and thirty three Rand and twenty one cents", "R233.21")]
        //[TestCase("Nine thousand nine hundred and ninety nine Rand and ninety nine cents", "R9999.99")]
        //[TestCase("Eight hundred and eleven Rand and twenty six cents", "R811.26")]
        //[TestCase("Eight hundred and one Rand", "R801.00")]
        public void ReturnsWord(string expected, string amount)
        {
            var solution = new CurrencyToWord.Solution();

            Assert.AreEqual(expected, solution.solution(amount));
        }
    }
}
