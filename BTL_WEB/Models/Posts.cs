using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_WEB.Models
{
    public class Posts
    {
        [Key]
        public int PostID { get; set; }
        [Required]
        
        public int AccountID {  get; set; }
        [ForeignKey("AccountID")]      
        public Accounts? Account { get; set; }

        public int CategoryID {  get; set; }
        [ForeignKey("CategoryID")]
        public Categories? Category { get; set; }

        [Required]
        public string? ImageUrl { get; set; }
        public string? Keyword{ get; set; }
        [Required]
        public bool isHot {  get; set; }
        [Required]
        public bool isNewfeed {  get; set; }
        [Required]
        public bool isAccept {  get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime Published {  get; set; }
    }
}
