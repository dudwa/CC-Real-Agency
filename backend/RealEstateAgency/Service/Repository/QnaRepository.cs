using RealEstateAgency.Data;

namespace RealEstateAgency.Service.Repository;

public class QnaRepository : IQnaRepository
{
    public List<Qna> GetAllQna()
    {
        using var dbContext = new QnaContext();
        return dbContext.Qnas.ToList();
    }

    public void Add(Qna qna)
    {
        using var dbContext = new QnaContext();
        dbContext.Add(qna);
        dbContext.SaveChanges();
    }
}