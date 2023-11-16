using Microsoft.EntityFrameworkCore;

namespace RealEstateAgency.Data;

public class RealEstateAgencyApiContext : DbContext
{
    public DbSet<RealEstate> RealEstates { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=RealEstateAgency;User Id=sa;Password=izagy01*;");
    }
}