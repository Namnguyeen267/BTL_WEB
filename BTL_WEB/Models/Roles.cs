using System.ComponentModel.DataAnnotations;

namespace BTL_WEB.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        [Required]
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
    }
}
