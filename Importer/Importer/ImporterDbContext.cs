using Microsoft.EntityFrameworkCore;

namespace Importer
{
    internal class ImporterDbContext : DbContext 
    {
        public DbSet<ImbalancePrice> ImbalancedPrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            string dbPath = Path.Join(path, "importer.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImbalancePrice>()
                .HasKey(x => new
                {
                    x.TimestampUtc,
                    x.Area
                });
        }
    }
}
