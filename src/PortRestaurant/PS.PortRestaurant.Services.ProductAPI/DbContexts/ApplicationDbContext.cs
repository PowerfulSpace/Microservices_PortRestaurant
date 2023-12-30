using Microsoft.EntityFrameworkCore;

namespace PS.PortRestaurant.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
    }
}
