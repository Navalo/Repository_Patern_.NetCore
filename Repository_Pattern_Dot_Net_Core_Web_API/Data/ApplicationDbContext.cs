using Microsoft.EntityFrameworkCore;
using Repository_Pattern_Dot_Net_Core_Web_API.Models;

namespace Repository_Pattern_Dot_Net_Core_Web_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
