using Microsoft.AspNetCore.Identity;

namespace API1.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

    }
}
