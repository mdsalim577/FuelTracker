using System.ComponentModel.DataAnnotations;

namespace FuelTracker.Domain
{
    public class FuelRecord
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Vehicle number is required")]
        public string VehicleNumber { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Fuel amount is required")]
        public double FuelAmount { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        public string DriverName { get; set; }

        [Required(ErrorMessage = "Fuel type is required")]
        [FuelTypeValidation(ErrorMessage = "Invalid fuel type. Supported values are Petrol and Diesel")]
        public string FuelType { get; set; }

    }

    public class FuelTypeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var allowedFuelTypes = new[] { "Petrol", "Diesel" }; // Add more if needed

            if (value != null && !allowedFuelTypes.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}