namespace BankApp
{
    class Branch(string branchCode, string city)
    {
        public string BranchCode { get; } = branchCode;
        public string City { get; } = city;

        public override string ToString()
        {
            return $"Branch Code: {BranchCode}, City: {City}";
        }
    }

}