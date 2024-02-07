using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStubbingApp
{
    [TestFixture]
    internal class StubListTest
    {
        [Test]
        public void Count_SubbedWithValue_ReturnsSameValue() { 
        
            // Arrange and Act
            var mockList = new Mock<IList<int>>();
            var expectedCount = 100;
            mockList.Setup(x => x.Count).Returns(expectedCount);

            // Assert
            Assert.That(mockList.Object.Count, Is.EqualTo(expectedCount));

        }

        [Test]
        public void Index_Stubbed_ReturnsIndexerValue()
        {
        
            // Arrange and Act
            var mockList = new Mock<IList<string>>();
            mockList.Setup(x => x[0]).Returns(() => "Hello subbed");

            // Assert
            Assert.That(mockList.Object[0], Is.EqualTo("Hello subbed"));
            Assert.That(mockList.Object[1], Is.Null);

        }
        [Test]
        public void Index_StubbedWithAnyInteger_ReturnsIndexerValue()
        {
        
            // Arrange and Act
            var mockList = new Mock<IList<string>>();
            mockList.Setup(x=>x[It.IsAny<int>()])
                .Returns((int index)=>" Hello subbed "+index);

            // Assert

            Assert.That(mockList.Object[0], Is.EqualTo(" Hello subbed 0"));
            Assert.That(mockList.Object[100], Is.EqualTo(" Hello subbed 100"));
            Assert.That(mockList.Object[2], Is.EqualTo(" Hello subbed 2"));

        }

        [Test]
        public void Index_StubbedWithAnyInteger_ReturnsApplicationException()
        {

            // Arrange and Act
            var mockList = new Mock<IList<string>>();
          
            mockList.Setup(x => x[It.IsAny<int>()])
                .Throws<ApplicationException>();

            // Assert

            Assert.Throws<ApplicationException>(() => { 
             var r= mockList.Object[0];
            });

            Assert.Throws<ApplicationException>(() => {
                var r = mockList.Object[100];
            });

        }

        [Test]
        public void VerifyAdd_CalledThrice()
        {
            // Arrange
            var mockList = new Mock<IList<string>>();

            var item="Hello";
            mockList.Object.Add(item);
            mockList.Object.Add(item);
            mockList.Object.Add(item);


            mockList.Verify(x=>x.Add(item), Times.Exactly(3));
            mockList.Verify(x=>x.Remove(item),Times.Never);  

        }

    }
}
