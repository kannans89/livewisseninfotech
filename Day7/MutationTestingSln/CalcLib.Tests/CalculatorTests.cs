using NUnit.Framework;

namespace CalcLib.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _sut;

        [SetUp]
        public void Init()
        {
            _sut = new Calculator();
        }

        [TestCase(5, 5, 10)]
        public void Add_PositiveIntInput_ReturnsInt(int first, int second, int expected)
        {

            var result = _sut.Add(first, second);

            Assert.That(result, Is.EqualTo(expected));
        }
        [TestCase(5, 5, 0)]
        public void Subtract_PositiveIntInput_ReturnsInt(int first, int second, int expected)
        {

            var result = _sut.Subtract(first, second);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, 1, 1)]
        [TestCase(2, 2, 4)]
        public void Mulitply_PositiveIntInput_ReeturnsInt(int first, int second, int expected)
        {

            var result = _sut.Mulitply(first, second);

            Assert.That(result, Is.EqualTo(expected));
        }

        //[Ignore("")]
        [TestCase(1, 1, 1, 0)]
        [TestCase(5, 2, 2, 1)]
        public void Divide_PositiveIntInput_ReeturnsInt(int first, int second, int expectedResult, int expectedReminder)
        {

            var result = _sut.Divide(first, second);

            Assert.That(result.Result, Is.EqualTo(expectedResult));
            Assert.That(result.Reminder, Is.EqualTo(expectedReminder));
        }

        [Test]

        [TestCase(10, 0)]
        public void Divide_ByZero_ReeturnsException(int first, int second)
        {

            Assert.Throws<DivideByZeroException>(() => {
                var result = _sut.Divide(first, second);
            });



        }
    }
}
