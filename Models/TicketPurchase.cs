using System.ComponentModel.DataAnnotations;

namespace TicketHubApp.Models
{
    public class TicketPurchase
    {
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^[+]?[(]?[0-9]{1,4}[)]?[-\s./0-9]*$", ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Credit Card is required")]
        [CreditCard(ErrorMessage = "Invalid credit card format")]
        [RegularExpression(@"^(\d{4}[-\s]?){3}\d{4}$", ErrorMessage = "Invalid credit card number format.")]
        public string CreditCard { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration is required")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$", ErrorMessage = "Invalid expiration date format. Format: MM/YY or MM/YYYY")]
        public string Expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Security Code is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Security Code must be 3 or 4 digits.")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s,.-]+$", ErrorMessage = "Address can contain letters, numbers, spaces, commas, periods, and hyphens.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City name can only contain letters and spaces.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Province name can only contain letters and spaces.")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal Code is required")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Invalid postal code format. Format: A1A 1A1")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Country name can only contain letters and spaces.")]
        public string Country { get; set; } = string.Empty;
    }
}
