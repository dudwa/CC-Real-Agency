using Microsoft.EntityFrameworkCore;

namespace RealEstateAgency.Data;

public class RealEstateAgencyContext : DbContext
{
    public DbSet<RealEstate> RealEstates { get; set; }
    public DbSet<Qna> Qnas { get; set; }

    public RealEstateAgencyContext(DbContextOptions<RealEstateAgencyContext> options) : base(options)
    {
    }
}