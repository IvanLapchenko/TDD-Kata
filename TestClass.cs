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
    }
}
