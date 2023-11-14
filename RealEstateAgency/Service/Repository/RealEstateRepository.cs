using RealEstateAgency.Data;

namespace RealEstateAgency.Service.Repository;

public class RealEstateRepository : IRealEstateRepository
{
    public List<RealEstate> GetAll()
    {
        using var dbContext = new RealEstateAgencyApiContext();
        return dbContext.RealEstates.ToList();
    }

    public void Add(RealEstate realEstate)
    {
        using var dbContext = new RealEstateAgencyApiContext();
        dbContext.Add(realEstate);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        using var dbContext = new RealEstateAgencyApiContext();
        RealEstate realEstateToRemove = new RealEstate() {Id = id};
        dbContext.Remove(realEstateToRemove);
        dbContext.SaveChanges();
    }
    
    public void Update(RealEstate realEstate)
    {  
        using var dbContext = new RealEstateAgencyApiContext();
        var realEstatetoupdate = dbContext.RealEstates.Find(realEstate.Id);
        realEstatetoupdate = realEstate;
        dbContext.SaveChanges();
    }
}