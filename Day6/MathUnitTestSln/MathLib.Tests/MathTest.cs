using NUnit.Framework;

namespace MathLib.Tests
{

    [TestFixture]
    public class MathTest
    {
        private Math _math;

        [SetUp]
        public void SetUp()//Arraange
        {
            _math = new Math();
        }

        [Test]
        public void CubeEvenNo_WhenEvenNo_ReturnsCube() { 
        
            // Arrange
          //  var math = new Math();
            var expected = 8;   
            // Act
            var result = _math.CubeEvenNo(2);
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CubeEvenNo_WhenOddNo_ThrowsArgumentException()
        {
        
            // Arrange
            //var math = new Math();
            // Act and assert
            Assert.Throws<ArgumentException>(() => _math.CubeEvenNo(3));
        }

        [Test]
        [TestCase(7,true)]
        [TestCase(11, true)]
        [TestCase(8, false)]
        [TestCase(1, false)]
        public void  IsPrime_WhenCalled_ReturnsTrueIfPrimeElseFalse(int input, bool expected)
        {
        
            // Arrange
            //var math = new Math();
            // Act
            var result = _math.IsPrime(input);
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, 10, new int[] { 2, 3, 5, 7 })]
        [TestCase(1, 20, new int[] { 3, 5, 7, 11, 13, 17, 19 ,2})]
        public void GetPrimes_WhenCalled_ReturnsListOfPrimes(int from, int to, int[] expected)
        {
        
            // Arrange
            //var math = new Math();
            // Act
            var result = _math.GetPrimes(from, to);
            // Assert
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void SayHello_WhenCalled_ReturnsHelloName()
        {
        
            // Arrange
             var expected = "Hello TDD";
            // Act
            var result = _math.SayHello("TDD");
            // Assert
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Does.Contain("TDD"));
            Assert.That(result, Does.StartWith("Hello"));
            Assert.That(result, Is.Not.Empty);
        }
    }
}
