// BankAccount.cs
namespace BankingApp
{
    // Abstract base class for accounts
    public abstract class BankAccount : IAccount
    {
        // Encapsulated fields
        private readonly string _accountNumber;
        private readonly List<Transaction> _transactions = new List<Transaction>();

        // Protected so derived classes can access balance safely
        protected decimal _balance;

        public string AccountNumber => _accountNumber;
        public Customer Owner { get; }

        // Expose balance read-only to outside
        public decimal Balance => _balance;

        // Read-only view of transaction history
        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

        // Constructor ensures account initialization
        protected BankAccount(string accountNumber, Customer owner, decimal initialDeposit = 0m)
        {
            if (string.IsNullOrWhiteSpace(accountNumber)) throw new ArgumentException("Account number required.");
            _accountNumber = accountNumber;
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            if (initialDeposit < 0) throw new ArgumentException("Initial deposit cannot be negative.");
            if (initialDeposit > 0)
            {
                _balance = initialDeposit;
                RecordTransaction(new Transaction(TransactionType.Deposit, initialDeposit, _balance, "Initial deposit"));
            }
        }

        // Encapsulated helper to record transactions
        protected void RecordTransaction(Transaction t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));
            _transactions.Add(t);
        }

        // Deposit - public API, validates amount
        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Deposit amount must be positive.");
            _balance += amount;
            RecordTransaction(new Transaction(TransactionType.Deposit, amount, _balance));
        }

        // Withdraw - virtual so derived classes can change behavior (e.g., overdraft)
        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Withdrawal amount must be positive.");
            if (amount > _balance) throw new InvalidOperationException("Insufficient funds.");
            _balance -= amount;
            RecordTransaction(new Transaction(TransactionType.Withdrawal, amount, _balance));
        }

        // Transfer helper - uses Withdraw & Deposit with recording as TransferIn/Out
        public void TransferTo(BankAccount destination, decimal amount)
        {
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (destination == this) throw new InvalidOperationException("Cannot transfer to same account.");
            if (amount <= 0) throw new ArgumentException("Transfer amount must be positive.");

            // Withdraw from source - may throw if not allowed (overdraft, etc.)
            this.Withdraw(amount);
            RecordTransaction(new Transaction(TransactionType.TransferOut, amount, this._balance, $"To {destination.AccountNumber}"));

            // Deposit into destination but record as TransferIn
            destination._balance += amount;
            destination.RecordTransaction(new Transaction(TransactionType.TransferIn, amount, destination._balance, $"From {this.AccountNumber}"));
        }

        // Abstract: account-specific monthly interest calculation (0 for current accounts)
        public abstract decimal CalculateMonthlyInterest();

        // Apply monthly interest and record it
        public void ApplyMonthlyInterest()
        {
            var interest = CalculateMonthlyInterest();
            if (interest > 0)
            {
                _balance += interest;
                RecordTransaction(new Transaction(TransactionType.Interest, interest, _balance, "Monthly interest"));
            }
        }

        public virtual string GetAccountSummary()
        {
            return $"{GetType().Name} {AccountNumber} | Owner: {Owner.FullName} | Balance: {Balance:C}";
        }

        public void PrintStatement()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(GetAccountSummary());
            Console.WriteLine("Transactions:");
            foreach (var t in Transactions)
            {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
