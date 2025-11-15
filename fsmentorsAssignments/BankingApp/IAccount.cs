// Program.cs

namespace BankingApp
{
    public interface IAccount
    {
        string AccountNumber { get; }
        decimal Balance { get; }
        Customer Owner { get; }
        IReadOnlyList<Transaction> Transactions { get; }

        void ApplyMonthlyInterest();
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
}