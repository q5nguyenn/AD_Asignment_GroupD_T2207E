using System.ComponentModel.DataAnnotations;

namespace AD_Asignment_GroupD_T2207E.Models
{
    public class LoginModel
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
