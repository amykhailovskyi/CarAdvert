using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CA.Data.Entities
{
    public class FuelType : BaseEntity
    {
        /// <summary>
        /// Name of fuel.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(24)]
        public string Name { get; set; }


        //Navigation properties

        public virtual ICollection<CarAdvert> Adverts { get; set; }
    }
}