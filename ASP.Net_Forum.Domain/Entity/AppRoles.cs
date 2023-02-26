using Microsoft.AspNetCore.Identity;

namespace Registr_Identity.Models
{
    public class AppRoles : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
