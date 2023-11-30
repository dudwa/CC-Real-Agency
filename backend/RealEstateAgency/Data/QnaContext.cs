namespace RealEstateAgency.Data;

using Microsoft.EntityFrameworkCore;

public class QnaContext : DbContext
{
    public DbSet<Qna> Qnas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=RealEstateAgency;User Id=sa;Password=!DbPassword12345;TrustServerCertificate=true;");
    }
}