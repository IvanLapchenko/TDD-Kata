using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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

    }
}
