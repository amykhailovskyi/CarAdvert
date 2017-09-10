using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CA.Data.Entities
{
    public class CarAdvert
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Title of the advertisement.
        /// </summary>
        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        /// <summary>
        /// Type id of fuel.
        /// </summary>
        [Required]
        public int FuelTypeId { get; set; }

        /// <summary>
        /// The price of car.
        /// </summary>
        [Required]
        public int Price { get; set; }

        /// <summary>
        /// Indicates if car is new or used.
        /// </summary>
        public bool New { get; set; }

        /// <summary>
        /// Number of mileages. For used car.
        /// </summary>
        public int Mileage { get; set; }

        /// <summary>
        /// Date of the first registration. For used car.
        /// </summary>
        public DateTime? FirstRegistration { get; set; }

        
        // Navigation properties

        [ForeignKey("FuelTypeId")]
        public virtual FuelType Fuel { get; set; }
    }
}
