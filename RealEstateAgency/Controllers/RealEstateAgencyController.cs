using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Data;
using RealEstateAgency.Service.Repository;

namespace RealEstateAgency.Controllers;

[ApiController]
[Route("[controller]")]
public class RealEstateAgencyController : ControllerBase
{
    
    [HttpGet("ForSale/")]
    public List<RealEstate> GetRealEstateAgencyForSale()
    {
        var repository = new RealEstateRepository();
        return repository.GetAllForSale();
    }

    [HttpGet("ToRent/")]
    public List<RealEstate> GetRealEstateAgencyToRent()
    {
        var repository = new RealEstateRepository();
        return repository.GetAllToRent();
    }
    
    [HttpGet("AllByUser/{id}")]
    public List<RealEstate> GetRealEstateAgencyByUser(int userId)
    {
        var repository = new RealEstateRepository();
        return repository.GetAllByUser(userId);
    }
    
}