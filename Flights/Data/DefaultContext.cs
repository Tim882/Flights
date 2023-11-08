using Flights.Models;
using Microsoft.EntityFrameworkCore;

namespace Flights.Data
{
	public class DefaultContext: DbContext
	{
		public DbSet<Document> Documents { get; set; } = null!;
		public DbSet<Passenger> Passengers { get; set; } = null!;
		public DbSet<Ticket> Tickets { get; set; } = null!;

        public DefaultContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}

