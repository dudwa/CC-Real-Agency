using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using RealEstateAgency.Data;
using RealEstateAgency.Service.Repository;

namespace RealEstateAgency.Controllers;

[ApiController]
[Route("[controller]")]
public class QnaController : ControllerBase
{
    private readonly IQnaRepository _qnaRepository;

    public QnaController(IQnaRepository qnaRepository)
    {
        _qnaRepository = qnaRepository;
    }

    [HttpGet("getall/")]
    public IActionResult GetQnas()
    {
        try
        {
            return Ok(_qnaRepository.GetAllQna());
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
            _qnaRepository.Add(qna);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }
}