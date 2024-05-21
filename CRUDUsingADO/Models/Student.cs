using System.ComponentModel.DataAnnotations;

namespace CRUDUsingADO.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public Double Percentage
        {
            get; set;
        }
    }
}
