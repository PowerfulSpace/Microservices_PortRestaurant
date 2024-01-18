using Microsoft.AspNetCore.Identity;
using PS.PortRestaurant.Services.Identity.DbContexts;
using PS.PortRestaurant.Services.Identity.Models;

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
                UserName = "",
                Email = "",
                EmailConfirmed = true,
                PhoneNumber = ""
            };




        }
    }
}
