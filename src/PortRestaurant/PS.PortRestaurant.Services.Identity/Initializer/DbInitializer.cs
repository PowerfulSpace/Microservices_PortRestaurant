using IdentityModel;
using Microsoft.AspNetCore.Identity;
using PS.PortRestaurant.Services.Identity.DbContexts;
using PS.PortRestaurant.Services.Identity.Models;
using System.Security.Claims;

namespace PS.PortRestaurant.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if(_roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
            }
            else { return; }


            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FistName = "Alexander",
                LastName = "Admin"
            };

            _userManager.CreateAsync(adminUser,"Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser,SD.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,adminUser.FistName+" "+adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName,adminUser.FistName),
                new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                new Claim(JwtClaimTypes.Role,SD.Admin)
            }).Result;

        }
    }
}
