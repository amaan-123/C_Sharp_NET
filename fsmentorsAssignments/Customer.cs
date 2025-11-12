namespace BankApp
{
    public class Customer(string firstname = "Salaam", string lastname = "Sahab", string address = "My Home, Your Lane, Our Colony, Their City, Fun Country")
    {
        public int _customerId { get; set; } //= GenerateCustomerId();//todo
        private string _firstName { get; set; } = firstname;
        private string _lastName { get; set; } = lastname;

        private string _address { get; set; } = address;

        //public static int GenerateCustomerId()//todo
        //{

        //    return _customerId;
        //}
        public override string ToString()
        {
            return $"CustomerId: {_customerId}, Firstname: {_firstName}, Lastname: {_lastName}, Address: {_address}";
        }
    }

}