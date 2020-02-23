using Microsoft.EntityFrameworkCore;

namespace specflow_demo.data
{
	public class LocalDbContext : DbContext
	{
		public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
		{
		}

		public DbSet<Weather> Weathers { get; set; }
	}
}
