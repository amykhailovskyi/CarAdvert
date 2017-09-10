using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CA.Data.Entities
{
    public class FuelType
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of fuel.
        /// </summary>
        [Required]
        public string Name { get; set; }

        //Navigation properties

        public virtual ICollection<CarAdvert> Adverts { get; set; }
    }
}