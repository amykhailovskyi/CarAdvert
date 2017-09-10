using System.ComponentModel.DataAnnotations;

namespace CA.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}