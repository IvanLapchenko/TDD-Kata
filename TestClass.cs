using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NuGet.Frameworks;


namespace TDD_Kata
{
    [TestFixture]
    internal class TestClass
    {
        [Test]
        public void TakesVoidReturnsZero()
        {
            StringCalculator stringCalculator = new();
            Assert.AreEqual(0, stringCalculator.Add(""));
        }
        [Test]
        public void TakesOneReturnsThis()
        {
            StringCalculator stringCalculator = new();
            Assert.AreEqual(1, stringCalculator.Add("1"));
        }
        [Test]
        public void TakesTwoReturnsSum()
        {
            StringCalculator stringCalculator = new();
            Assert.AreEqual(4, stringCalculator.Add("1,3"));
        }
        [Test]
        public void TakesWithNewlineAndIgnoresIt()
        {
            StringCalculator stringCalculator = new();
            Assert.AreEqual(6, stringCalculator.Add("1\n2,3"));
        }
        [Test]
        public void TakesDelimiterAndIgnoresIt()
        {
            StringCalculator stringCalculator = new();
            Assert.AreEqual(3, stringCalculator.Add("//;\n1;2"));
        }
        [Test]
        public void TakesNegativeReturnsException()
        {
            StringCalculator stringCalculator = new();

            ArgumentException ex = Assert.Throws<ArgumentException>(delegate { stringCalculator.Add("//;\n1;-2"); });
            Assert.That(ex.Message, Is.EqualTo("message"));
        }

    }
}
