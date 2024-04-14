using System.ComponentModel.DataAnnotations;

namespace BTL_WEB.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        [Required]
        public string? CategoryDescription { get; set;}
    }
}
