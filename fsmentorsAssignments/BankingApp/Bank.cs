// Bank.cs
namespace BankingApp
{
    // Simple Bank manager to create accounts and do top-level operations
    public class Bank
    {
        private readonly Dictionary<string, BankAccount> _accounts = new Dictionary<string, BankAccount>();
        private int _accountNumberSeed = 1000000;

        // Encapsulated account creation - returns the account object
        public BankAccount CreateSavingsAccount(Customer owner, decimal initialDeposit, decimal annualInterestRate)
        {
            var accNum = GenerateAccountNumber();
            var acc = new SavingsAccount(accNum, owner, initialDeposit, annualInterestRate);
            _accounts.Add(accNum, acc);
            return acc;
        }

        public BankAccount CreateCurrentAccount(Customer owner, decimal initialDeposit, decimal overdraftLimit = 0m)
        {
            var accNum = GenerateAccountNumber();
            var acc = new CurrentAccount(accNum, owner, initialDeposit, overdraftLimit);
            _accounts.Add(accNum, acc);
            return acc;
        }

        private string GenerateAccountNumber()
        {
            _accountNumberSeed++;
            return _accountNumberSeed.ToString();
        }

        public BankAccount? GetAccount(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber)) return null;
            _accounts.TryGetValue(accountNumber, out var acc);
            return acc;
        }

        public void Transfer(string fromAccNum, string toAccNum, decimal amount)
        {
            var from = GetAccount(fromAccNum) ?? throw new InvalidOperationException("Source account not found.");
            var to = GetAccount(toAccNum) ?? throw new InvalidOperationException("Destination account not found.");
            from.TransferTo(to, amount);
        }

        public IEnumerable<BankAccount> GetAllAccounts() => _accounts.Values.ToList().AsReadOnly();
    }
}
