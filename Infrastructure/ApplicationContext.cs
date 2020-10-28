using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationContext
    {
        public class ApplicationContext : DbContext, IApplicationContext
        {
            public ApplicationContext(DbContextOptions options) : base(options)
            {
            }

            public DbSet<Product> Products { get; set; }
            public async Task<int> SaveChanges()
            {
                return await base.SaveChangesAsync();
            }
        }
    }
}