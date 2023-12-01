using Microsoft.AspNetCore.Identity;

namespace AD_Asignment_GroupD_T2207E.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
