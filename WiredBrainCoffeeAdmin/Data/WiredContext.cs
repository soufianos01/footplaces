using Microsoft.EntityFrameworkCore;
using FootballField.Data.Models;

namespace FootballField.Data
{
	public class WiredContext : DbContext
	{
		public WiredContext(DbContextOptions options) : base(options) { }
		public DbSet<BookedField> BookedFields { get; set; }
	}
}
