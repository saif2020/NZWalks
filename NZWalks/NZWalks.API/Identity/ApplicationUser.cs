using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? PersonName { get; set; }
    }
}
