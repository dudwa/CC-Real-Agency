using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Data;
using RealEstateAgency.Service.Repository;

namespace RealEstateAgency.Controllers;

[ApiController]
[Route("[controller]")]
public class RealEstateController : ControllerBase
{
    [HttpGet("forsale/"), Authorize]
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

    [HttpGet("torent/"), Authorize]
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

    [HttpGet("byuser/{id}"), Authorize]
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

    [HttpPost("add/"), Authorize]
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