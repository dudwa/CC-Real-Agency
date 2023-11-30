using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Data;
using RealEstateAgency.Service.Repository;

namespace RealEstateAgency.Controllers;

[ApiController]
[Route("[controller]")]
public class QnaController : ControllerBase
{
    [HttpGet("getall/")]
    public IActionResult GetQnas()
    {
        try
        {
            var repository = new QnaRepository();
            return Ok(repository.GetAllQna());
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }

    [HttpPost("add/"), Authorize(Roles = "Admin")]
    public IActionResult AddQna(Qna qna)
    {
        try
        {
            var repository = new QnaRepository();
            repository.Add(qna);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }
}