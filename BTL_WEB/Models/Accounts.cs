using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_WEB.Models
{
    public class Accounts
    {
        [Key]
        public int AccountID { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }

        public int RoleID { get; set;}
        [ForeignKey("RoleID")]
        public Roles? Role { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }=DateTime.UtcNow;

    }
}
