using System.ComponentModel.DataAnnotations;

namespace ProductAPI.DTOs
{
    public class ProductValidationExample
    {
        [Required]                                    // Field is mandatory
        [StringLength(50, MinimumLength = 3)]        // String length constraints
        [RegularExpression(@"^[a-zA-Z\s]+$")]       // Regex pattern
        public string Name { get; set; }

        [Range(0.01, double.MaxValue)]              // Numeric range
        [DataType(DataType.Currency)]               // Data type hint
        public decimal Price { get; set; }

        [EmailAddress]                              // Email format validation
        public string Email { get; set; }

        [Phone]                                     // Phone number validation
        public string PhoneNumber { get; set; }

        [Url]                                       // URL format validation
        public string Website { get; set; }
    }
}

