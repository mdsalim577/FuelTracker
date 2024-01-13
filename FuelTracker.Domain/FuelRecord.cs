using System.ComponentModel.DataAnnotations;

namespace FuelTracker.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class FuelRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VehicleNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double FuelAmount { get; set; }

        [Required]
        public double Price { get; set; }

        public string Name { get; set; }
    }
}