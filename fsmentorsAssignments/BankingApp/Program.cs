// Program.cs
namespace BankingApp
{
    // Enum for transaction types
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        TransferIn,
        TransferOut,
        Interest
    }

    // Immutable record for transactions to preserve history safely
    public class Transaction
    {
        public DateTime Timestamp { get; }
        public TransactionType Type { get; }
        public decimal Amount { get; }
        public string? Note { get; }
        public decimal BalanceAfter { get; }

        public Transaction(TransactionType type, decimal amount, decimal balanceAfter, string? note = null)
        {
            Timestamp = DateTime.UtcNow;
            Type = type;
            Amount = amount;
            BalanceAfter = balanceAfter;
            Note = note;
        }

        public override string ToString()
        {
            return $"{Timestamp:u} | {Type} | {Amount:C} | Balance: {BalanceAfter:C} | {Note}";
        }
    }

    // Simple customer entity
    public class Customer
    {
        // private backing fields for encapsulation
        private readonly string _customerId;
        private string _fullName;
        private string? _address;

        // Public read-only CustomerId
        public string CustomerId => _customerId;

        // FullName exposed via property; allow name update through setter if needed
        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be empty.");
                _fullName = value.Trim();
            }
        }

        // Address is optional and can be updated
        public string? Address
        {
            get => _address;
            set => _address = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }

        public Customer(string customerId, string fullName, string? address = null)
        {
            _customerId = customerId ?? throw new ArgumentNullException(nameof(customerId));
            FullName = fullName;
            Address = address;
        }

        public override string ToString() => $"{FullName} (ID: {_customerId})";
    }

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

    // Savings account: earns interest
    public class SavingsAccount : BankAccount
    {
        // interestRate in annual terms (e.g., 0.04m = 4%)
        private readonly decimal _annualInterestRate;

        public SavingsAccount(string accountNumber, Customer owner, decimal initialDeposit, decimal annualInterestRate)
            : base(accountNumber, owner, initialDeposit)
        {
            if (annualInterestRate < 0) throw new ArgumentException("Interest rate cannot be negative.");
            _annualInterestRate = annualInterestRate;
        }

        // Simple monthly interest calculation (not compounded continuously)
        public override decimal CalculateMonthlyInterest()
        {
            // monthly interest = balance * (annualRate / 12)
            return Math.Round(Balance * (_annualInterestRate / 12m), 2);
        }
    }

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

    // Program demonstration: simulate some transactions
    class Program
    {
        static void Main()
        {
            // Create bank and customers
            var bank = new Bank();
            var alice = new Customer("CUST1001", "Alice Johnson", "123 Main St");
            var bob = new Customer("CUST1002", "Bob Singh", "456 Market Rd");

            // Open accounts
            var aliceSavings = bank.CreateSavingsAccount(alice, initialDeposit: 1000m, annualInterestRate: 0.04m); // 4% pa
            var bobCurrent = bank.CreateCurrentAccount(bob, initialDeposit: 500m, overdraftLimit: 200m);

            // Demonstrate deposit
            aliceSavings.Deposit(250m); // Alice deposits 250
            // Demonstrate withdrawal
            bobCurrent.Withdraw(100m); // Bob withdraws 100

            // Demonstrate transfer Alice -> Bob
            bank.Transfer(aliceSavings.AccountNumber, bobCurrent.AccountNumber, 200m);

            // Apply monthly interest for savings accounts
            aliceSavings.ApplyMonthlyInterest();
            bobCurrent.ApplyMonthlyInterest(); // no interest for current; safe to call

            // Attempt overdraft for Bob
            try
            {
                bobCurrent.Withdraw(800m); // 500 -100 +200 (from alice transfer) = 600 available, overdraft 200 => can withdraw up to 800.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Overdraft attempt failed: {ex.Message}");
            }

            // Print summaries and statements
            Console.WriteLine("BANK ACCOUNT SUMMARIES:");
            foreach (var acc in bank.GetAllAccounts())
            {
                Console.WriteLine(acc.GetAccountSummary());
            }

            Console.WriteLine();
            aliceSavings.PrintStatement();
            bobCurrent.PrintStatement();

            // End of simulation
            Console.WriteLine("Simulation complete.");
        }
    }
}
