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
        public void TransferFunds_WithSufficientFunds_UpdatesBalances()
        {
            // Arrange
            var fromAccount = new Account("12345", "John", 1000);
            var toAccount = new Account("54321", "Jane", 1000);
            var expectedFromAccountBalance = 500;
            var expectedToAccountBalance = 1500;

            var logMock = new Mock<ILogger>();
            var accountService = new AccountService(logMock.Object);
            accountService.TransferFunds(fromAccount, toAccount, 501);

            Assert.That(fromAccount.Balance, Is.EqualTo(expectedFromAccountBalance));
            Assert.That(toAccount.Balance, Is.EqualTo(expectedToAccountBalance));


            
        }
    }
}
