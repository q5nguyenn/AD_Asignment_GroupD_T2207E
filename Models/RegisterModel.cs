using System.ComponentModel.DataAnnotations;

namespace AD_Asignment_GroupD_T2207E.Models
{
    public class RegisterModel
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
