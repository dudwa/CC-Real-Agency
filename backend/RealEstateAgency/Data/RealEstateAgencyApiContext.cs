using Microsoft.EntityFrameworkCore;

namespace RealEstateAgency.Data;

public class RealEstateAgencyApiContext : DbContext
{
    public DbSet<RealEstate> RealEstates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=RealEstateAgency;User Id=sa;Password=!DbPassword12345;TrustServerCertificate=true;");
    }
}