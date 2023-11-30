using RealEstateAgency.Data;
using RealEstateAgency.Model;

namespace RealEstateAgency.Service.Repository;

public class RealEstateRepository : IRealEstateRepository
{
    
    public List<RealEstate> GetAll()
    {
        using var dbContext = new RealEstateAgencyContext();
        return dbContext.RealEstates.ToList();
    }
    
    public List<RealEstate> GetAllForSale()
    {
        using var dbContext = new RealEstateAgencyContext();
        return dbContext.RealEstates.Where(re => re.Status == RealEstateStatus.ForSale).ToList();
    }

    public List<RealEstate> GetAllToRent()
    {
        using var dbContext = new RealEstateAgencyContext();
        return dbContext.RealEstates.Where(re => re.Status == RealEstateStatus.ToRent).ToList();
    }

    public List<RealEstate> GetAllByUser(int userId)
    {
        using var dbContext = new RealEstateAgencyContext();
        return dbContext.RealEstates.Where(re => re.UserId == userId).ToList();
    }

    public void Add(RealEstate realEstate)
    {
        using var dbContext = new RealEstateAgencyContext();
        dbContext.Add(realEstate);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        using var dbContext = new RealEstateAgencyContext();
        RealEstate realEstateToRemove = new RealEstate() { Id = id };
        dbContext.Remove(realEstateToRemove);
        dbContext.SaveChanges();
    }

    public void Update(RealEstate realEstate)
    {
        using var dbContext = new RealEstateAgencyContext();
        var realEstatetoupdate = dbContext.RealEstates.Find(realEstate.Id);
        realEstatetoupdate = realEstate;
        dbContext.SaveChanges();
    }
}