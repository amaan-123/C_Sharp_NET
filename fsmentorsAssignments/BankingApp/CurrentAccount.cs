// CurrentAccount.cs
namespace BankingApp
{
    // Current account: may allow overdraft up to a limit
    public class CurrentAccount : BankAccount
    {
        private readonly decimal _overdraftLimit; // positive number representing allowed negative balance

        public CurrentAccount(string accountNumber, Customer owner, decimal initialDeposit, decimal overdraftLimit = 0m)
            : base(accountNumber, owner, initialDeposit)
        {
            if (overdraftLimit < 0) throw new ArgumentException("Overdraft limit cannot be negative.");
            _overdraftLimit = overdraftLimit;
        }

        // Allow withdrawal up to balance + overdraftLimit
        public override void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Withdrawal amount must be positive.");

            if (amount > Balance + _overdraftLimit)
                throw new InvalidOperationException("Insufficient funds including overdraft.");

            _balance -= amount;
            RecordTransaction(new Transaction(TransactionType.Withdrawal, amount, _balance, "Current account withdrawal"));
        }

        // No interest on current accounts in this simple model
        public override decimal CalculateMonthlyInterest() => 0m;
    }
}
