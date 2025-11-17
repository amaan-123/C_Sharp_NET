// Customer.cs
namespace BankingApp
{
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
}
