using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Data;
using RealEstateAgency.Service.Repository;

namespace RealEstateAgency.Controllers;

[ApiController]
[Route("[controller]")]
public class RealEstateAgencyController : ControllerBase
{
    [HttpGet("GetAll/")]
    public List<RealEstate> GetRealEstateAgencyGetAll()
    {
        var repository = new RealEstateRepository();
        return repository.GetAll();
    }

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
    
    [HttpPost("RealEstate/Add/")]
    public IActionResult AddRealEstate(RealEstate realEstate)
    {
        try
        {
            var repository = new RealEstateRepository();
            repository.Add(realEstate);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
        
    }
}