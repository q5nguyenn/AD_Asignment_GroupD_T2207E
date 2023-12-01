using System.ComponentModel.DataAnnotations;

namespace AD_Asignment_GroupD_T2207E.Models.Authentication
{
	public class Login
	{
		[EmailAddress(ErrorMessage = "*Email không đúng định dạng.")]
		[Required(ErrorMessage = "*Email không được để trống.")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "*Mật khẩu không được để trống.")]
		public string Password { get; set; } = string.Empty;
		public bool RememberMe { get; set; }
	}
}
