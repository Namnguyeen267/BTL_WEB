using System.ComponentModel.DataAnnotations;

namespace BTL_WEB.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage ="Nhập tên người dùng")]
		public string? UserName { get; set; }
		[Required(ErrorMessage = "Nhập mật khẩu")]

		public string? Password { get; set; }
	}
}
