// SavingsAccount.cs
namespace BankingApp
{
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
}
