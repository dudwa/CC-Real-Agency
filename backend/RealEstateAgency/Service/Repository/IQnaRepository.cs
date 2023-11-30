using RealEstateAgency.Data;

namespace RealEstateAgency.Service.Repository;

public interface IQnaRepository
{
    List<Qna> GetAllQna();
    void Add(Qna qna);
}