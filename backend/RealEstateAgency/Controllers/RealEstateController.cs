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
        foreach (var cookie in Request.Cookies)
        {
            Console.WriteLine($"{cookie.Key}:{cookie.Value}");
        }
        
        foreach (var claim in User.Claims)
        {
            Console.WriteLine($"{claim.Type}: {claim.Value}");
        }
        
        /*
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userName = User.FindFirst(ClaimTypes.Name)?.Value;

        Console.WriteLine($"Authenticated User: {userId}, {userName}");
        */
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