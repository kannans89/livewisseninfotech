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
    internal class FooTest
    {
        [Test]
        public void Method1_Stubbed_ReturnNewValue()
        {

            var fooMock = new Mock<Foo>();
            fooMock.Setup(x=>x.Method1()).Returns("Hello subbed Method1");

            Assert.That(fooMock.Object.Method1(), Is.EqualTo("Hello subbed Method1"));
        }

        [Test]
        public void Method1_ShouldReturnOrginalValueWhenNotMocked()
        {
            var foo = new Foo();
            Assert.That(foo.Method1(), Is.EqualTo("Method1"));
        }
    }
}
