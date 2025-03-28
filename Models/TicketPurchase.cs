using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace TicketHubApp.Models
{
    [SwaggerSchema(Description = "Represents a ticket purchase request")]
    public class TicketPurchase
    {
        [SwaggerSchema(Description = "The ID of the concert")]
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        [SwaggerSchema(Description = "Email address of the purchaser")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        [SwaggerSchema(Description = "Full name of the purchaser")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^[+]?[(]?[0-9]{1,4}[)]?[-\s./0-9]*$", ErrorMessage = "Invalid phone number format.")]
        [SwaggerSchema(Description = "Contact phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        [SwaggerSchema(Description = "Number of tickets to purchase")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Credit Card is required")]
        [CreditCard(ErrorMessage = "Invalid credit card format")]
        [RegularExpression(@"^(\d{4}[-\s]?){3}\d{4}$", ErrorMessage = "Invalid credit card number format.")]
        [SwaggerSchema(Description = "Credit card number")]
        public string CreditCard { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration is required")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$", ErrorMessage = "Invalid expiration date format. Format: MM/YY or MM/YYYY")]
        [SwaggerSchema(Description = "Credit card expiration date (MM/YY or MM/YYYY)")]
        public string Expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Security Code is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Security Code must be 3 or 4 digits.")]
        [SwaggerSchema(Description = "Credit card security code (CVV)")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s,.-]+$", ErrorMessage = "Address can contain letters, numbers, spaces, commas, periods, and hyphens.")]
        [SwaggerSchema(Description = "Billing address")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City name can only contain letters and spaces.")]
        [SwaggerSchema(Description = "Billing city")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Province name can only contain letters and spaces.")]
        [SwaggerSchema(Description = "Billing province/state")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal Code is required")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Invalid postal code format. Format: A1A 1A1")]
        [SwaggerSchema(Description = "Billing postal code (Format: A1A 1A1)")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Country name can only contain letters and spaces.")]
        [SwaggerSchema(Description = "Billing country")]
        public string Country { get; set; } = string.Empty;
    }
}