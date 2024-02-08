using NUnit.Framework;

namespace AccountCoreLib.Tests
{
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void Deposit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            var account = new Account("12345", "John Doe", 1000);
            // Act
            account.Deposit(500);
            // Assert
            Assert.That(account.Balance, Is.EqualTo(1500));
        }
        [Test]
        [TestCase(1000, 500, 500)]
        [TestCase(1000, 300, 700)]
        public void Withdraw_WithSufficientFunds_UpdatesBalance(decimal initialBalance,decimal amoutn,decimal expected)
        {
            // Arrange
            var account = new Account("12345", "John Doe", initialBalance);
            // Act
            account.Withdraw(amoutn);
            // Assert
            Assert.That(account.Balance, Is.EqualTo(expected));
        }

        [Test]
        public void Withdraw_WithInsufficientFunds_ThrowsException()
        {
            // Arrange
            var account = new Account("12345", "John Doe", 1000);
            // Act and Assert
            Assert.Throws<Exception>(() => account.Withdraw(501));
        }
    }
}
