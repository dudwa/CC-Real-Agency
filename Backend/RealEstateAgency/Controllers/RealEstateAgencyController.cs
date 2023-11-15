using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Data;
using RealEstateAgency.Service.Repository;

namespace RealEstateAgency.Controllers;

[ApiController]
[Route("[controller]")]
public class RealEstateAgencyController : ControllerBase
{
    [HttpGet("RealEstate/GetAll/")]
    public IActionResult GetRealEstateAgencyGetAll()
    {
        try
        {
            var repository = new RealEstateRepository();
            return Ok(repository.GetAll());
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }

    [HttpGet("RealEstate/ForSale/")]
    public IActionResult GetRealEstateAgencyForSale()
    {
        try
        {
            var repository = new RealEstateRepository();
            return Ok(repository.GetAllForSale());
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }

    [HttpGet("RealEstate/ToRent/")]
    public IActionResult GetRealEstateAgencyToRent()
    {
        try
        {
            var repository = new RealEstateRepository();
            return Ok(repository.GetAllToRent());
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }
    
    [HttpGet("RealEstate/ByUser/{id}")]
    public IActionResult GetRealEstateAgencyByUser(int userId)
    {
        try
        {
            var repository = new RealEstateRepository();
            return Ok(repository.GetAllByUser(userId));
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
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