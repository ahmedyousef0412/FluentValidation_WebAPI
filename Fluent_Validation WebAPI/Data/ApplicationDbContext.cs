using Fluent_Validation_WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Validation_WebAPI.Data
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }


        public DbSet<User> Users { get; set; }
       
    }
}
