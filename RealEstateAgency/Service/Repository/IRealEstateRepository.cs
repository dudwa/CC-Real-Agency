using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateAgency.Data;

namespace RealEstateAgency.Service.Repository;

public interface IRealEstateRepository
{
    List<RealEstate> GetAllForSale();
    List<RealEstate> GetAllToRent();
    void Add(RealEstate realEstate);
    void Delete(int id);
    void Update(RealEstate realEstate);
}