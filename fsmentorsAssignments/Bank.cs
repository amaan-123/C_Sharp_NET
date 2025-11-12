namespace BankApp
{
    public class Bank(string name = "OOPS Bank of Code", string location = "OOPS HQ, See Sharp City", string code = "OOPS")
    {
        // Bank's Shared Properties
        public string Name { get; } = name;
        private string Location { get; } = location;
        public string Code { get; } = code;

        // Bank's Branch Methods
        internal List<Branch> branches = new List<Branch>();
        public void AddBranch(string branchCode = "000000", string city = "CityA")
        {
            branches.Add(new Branch(branchCode, city));
        }
        internal List<Branch> GetBranch(string branchCode)
        {
            var requiredBranch = (from branch in branches
                                  where branch.BranchCode == branchCode
                                  select branch).ToList();
            Console.WriteLine($"-------------------------------------------------------------------");
            if (requiredBranch.Count != 0)
            {
                PrintBranchInfo(requiredBranch);
            }
            else
            {
                Console.WriteLine($"Branch with code: {branchCode} doesn't exist");
            }
            return requiredBranch;
        }
        public void RemoveBranch(string branchCode)
        {
            var branchToRemove = GetBranch(branchCode);
            Console.WriteLine("Remove the branch having above details? Enter N to abort or Y to delete:");
            string? userInput = Console.ReadLine().Trim().ToLower();
            if (userInput == "y")
            {
                foreach (var branch in branchToRemove)
                {
                    branches.Remove(branch);
                    Console.WriteLine($"Removed branch having code: {branchCode}");
                }
            }
            else if (userInput == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("Enter y or n only");
                return;
            }
        }
        public void GetAllBranches()
        {
            Console.WriteLine($"-------------------------------------------------------------------");
            Console.WriteLine($"Bank HQ Address: {Location}");
            PrintBranchInfo(this.branches);
        }
        private void PrintBranchInfo(List<Branch> printingBranches)
        {
            foreach (var branch in printingBranches)
            {
                Console.WriteLine(branch);
            }
        }

    }
}