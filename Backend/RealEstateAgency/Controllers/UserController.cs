using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Data;
using RealEstateAgency.Service.Repository;

namespace RealEstateAgency.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAllUser()
    {
        try
        {
            var repository = new UserRepository();
            return Ok(repository.GetAll());
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }

    [HttpPost("Register")]
    public IActionResult Add(User user)
    {
        try
        {
            var repository = new UserRepository();
            repository.Add(user);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }
    
    [HttpPost("Login")]
    public IActionResult Login(string userNameOrEmail, string password)
    {
        try
        {
            var repository = new UserRepository();
            return Ok(repository.Login(userNameOrEmail, password).Id);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }

    [HttpPatch("{id}/PasswordChange")]
    public IActionResult UserPassword(int userId, string newPassword)
    {
        try
        {
            var repository = new UserRepository();
            repository.Update(userId, newPassword);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int userId)
    {
        try
        {
            var repository = new UserRepository();
            repository.Delete(userId);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Database error");
        }
    }
}