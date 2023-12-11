using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Data;

namespace RealEstateAgency.Service.Repository;

public class QnaRepository : IQnaRepository
{
    private readonly DbContextOptions<RealEstateAgencyContext> _dbContextOptions;

    public QnaRepository(DbContextOptions<RealEstateAgencyContext> dbContextOptions)
    {
        _dbContextOptions = dbContextOptions;
    }

    public List<Qna> GetAllQna()
    {
        using var dbContext = new RealEstateAgencyContext(_dbContextOptions);
        return dbContext.Qnas.ToList();
    }

    public void Add(Qna qna)
    {
        using var dbContext = new RealEstateAgencyContext(_dbContextOptions);
        dbContext.Add(qna);
        dbContext.SaveChanges();
    }
}