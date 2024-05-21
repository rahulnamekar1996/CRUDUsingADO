using System.ComponentModel.DataAnnotations;

namespace CRUDUsingADO.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Company { get; set; }
        [Required]
        public Double Price { get; set; }
    }

}
