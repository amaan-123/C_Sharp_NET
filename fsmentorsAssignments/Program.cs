namespace BankApp
{
    class Program
    {
        static void Main()
        {
            // Bank
            var myBank = new Bank();
            Console.WriteLine($"Welcome to {myBank.Name}");

            //Branch
            myBank.AddBranch(); // string branchCode = "000000", string city = "CityA"
            myBank.AddBranch("000001", "CityB");
            myBank.AddBranch("000002", "CityZ");
            myBank.GetAllBranches();
            myBank.GetBranch("000002");

            myBank.RemoveBranch("000000");
            myBank.GetBranch("000000");


            //var customerA = new Customer("Main", "Hoon", "Kahin Bhi");
            //var customerB = new Customer("Tum", "Ho", "Har Jagah");

            //var CustomerInfo = new Dictionary<int, Customer>();

            //Console.WriteLine($"Number of customers in bank: {CustomerInfo.Count}");



            //foreach (var customer in CustomerInfo)
            //{
            //    Console.WriteLine(customer);
            //}
        }
    }
}
