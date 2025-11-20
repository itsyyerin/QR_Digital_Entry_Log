using Microsoft.EntityFrameworkCore;
using QR_Digital_Entry_Log.Models;


namespace QR_Digital_Entry_Log.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<EntryLog> EntryLogs { get; set; }
    }
}
