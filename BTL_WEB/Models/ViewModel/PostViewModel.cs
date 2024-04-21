using System.ComponentModel.DataAnnotations;

namespace BTL_WEB.Models.ViewModel
{
    public class PostViewModel
    {
        public int PostID { get; set; }
        [Required]
        public string FullName { get; set; }
        public int AccountID { get; set; }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        public string? Keyword { get; set; }
        [Required]
        public bool isHot { get; set; }
        [Required]
        public bool isNewfeed { get; set; }
        [Required]
        public bool isAccept { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime Published { get; set; }
        public List<Accounts> AccountList = new List<Accounts>();
        public List<Categories> CategoryList = new List<Categories>();
    }
}
