// Program.cs
namespace BankingApp
{

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
