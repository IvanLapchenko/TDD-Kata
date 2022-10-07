using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NuGet.Frameworks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD_Kata
{
    [TestFixture]
    internal class TestClass
    {
        [AssemblyInitialize]
        public static void AssemblyInit()
        {
            StringCalculator stringCalculator = new();
        }
        [Test]
        public void TakesVoidReturnsZero()
        {
            
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

        }
    }
}
