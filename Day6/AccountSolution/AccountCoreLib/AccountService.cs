using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountCoreLib
{
    public class AccountService
    {
        private ILogger _logger;
        public AccountService(ILogger logger)
        {

            _logger = logger;
        }
        public void TransferFunds(Account fromAccount, Account toAccount, decimal amount)
        {
            if (fromAccount.Balance - amount < 500)
            {
                _logger.Log($"ERROR:Insufficient funds in account {fromAccount.AccountNumber}");
                throw new Exception("Insufficent funds");
            }

            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
            _logger.Log($"SUCCESS:Transferred {amount} from account {fromAccount.AccountNumber} to account {toAccount.AccountNumber}");
        }
    }
}
