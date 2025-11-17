// Transaction.cs
namespace BankingApp
{
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
}
