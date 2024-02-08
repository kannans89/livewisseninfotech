namespace AccountCoreLib
{
    public class Account
    {
        private string _accountNumber;
        private string _name;
        private decimal _balance;

        public Account(string accountNumber, string name, decimal balance)
        {
            _accountNumber = accountNumber;
            _name = name;
            _balance = balance;
        }
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public decimal Balance
        {
            get { return _balance; }

        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public void Deposit(decimal amount)
        {
            _balance += amount;
           // _balance -= amount;
        }
        public void Withdraw(decimal amount)
        {
            if (_balance - amount >= 500)
            {
                _balance -= amount;
              
            }
            else throw new Exception("Insufficient Funds");
           
        }

    }
}
