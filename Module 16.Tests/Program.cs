using NUnit.Framework;
using System;

namespace Module_16.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        Calculator calculator = new Calculator();
        [Test]
        public void Add_MustReturnTrueValue()
        {
            Assert.That(calculator.Additional(100, 200) == 300);
        }

        [Test]
        public void Subtract_MustReturnTrueValue()
        {
            Assert.That(calculator.Subtraction(300, 100) == 200);
        }

        [Test]
        public void Miltiplicate_MustReturnTrueValue()
        {
            Assert.That(calculator.Miltiplication(300, 100) == 30000);
        }

        [Test]
        public void Divide_MustReturnTrueValue()
        {
            Assert.That(calculator.Division(300, 100) == 3);
        }

        [Test]
        public void Divide_MustThrowException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Division(100, 0));
        }
    }
}
