using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountCoreLib.Tests
{
    [TestFixture]
    public class AccountServiceTest
    {
        [Test]
        public void TransferFunds_WithSufficientFunds_UpdatesBalancesAndLogsSuccess()
        {
            // Arrange
            var fromAccount = new Account("12345", "John", 1000);
            var toAccount = new Account("54321", "Jane", 1000);
            var expectedFromAccountBalance = 500;
            var expectedToAccountBalance = 1500;

            var logMock = new Mock<ILogger>();
            var accountService = new AccountService(logMock.Object);
            accountService.TransferFunds(fromAccount, toAccount, 500);

            Assert.That(fromAccount.Balance, Is.EqualTo(expectedFromAccountBalance));
            Assert.That(toAccount.Balance, Is.EqualTo(expectedToAccountBalance));
            logMock.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
            logMock.Verify(l => l.Log(It.Is<string>((m)=>m.Contains("SUCCESS"))));
        }

        [Test]
        public void TransferFunds_WithInsufficientFunds_ThrowsExceptionAndLogsError()
        {
            // Arrange
            var fromAccount = new Account("12345", "John", 1000);
            var toAccount = new Account("54321", "Jane", 1000);
           

            var logMock = new Mock<ILogger>();
            var sut = new AccountService(logMock.Object);
            Assert.Throws<Exception>(() => sut.TransferFunds(fromAccount, toAccount, 1500));

            logMock.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
        }

       
    }
}
