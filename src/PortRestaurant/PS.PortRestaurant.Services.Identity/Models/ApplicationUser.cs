using Microsoft.AspNetCore.Identity;

namespace PS.PortRestaurant.Services.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FistName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
