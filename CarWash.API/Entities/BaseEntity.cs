using System.ComponentModel.DataAnnotations;

namespace CarWash.Entities
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
