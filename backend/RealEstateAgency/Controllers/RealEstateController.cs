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
    private readonly IRealEstateRepository _realEstateRepository;

    public RealEstateController(IRealEstateRepository realEstateRepository)
    {
        _realEstateRepository = realEstateRepository;
    }

    [HttpGet("forsale/"), Authorize]
    public IActionResult GetRealEstateAgencyForSale()
    {
        try
        {
            return Ok(_realEstateRepository.GetAllForSale());
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
            return Ok(_realEstateRepository.GetAllToRent());
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
            return Ok(_realEstateRepository.GetAllByUser(userId));
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
            _realEstateRepository.Add(realEstate);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }
}