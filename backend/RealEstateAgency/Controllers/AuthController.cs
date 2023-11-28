using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Contracts;
using RealEstateAgency.Service.Authentication;

namespace RealEstateAgency.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authenticationService;

    public AuthController(IAuthService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Console.WriteLine(request.ToString());
        var result = await _authenticationService.RegisterAsync(request.Email, request.Username, request.Password, request.PhoneNumber, request.Firstname, request.Lastname);

        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }
        
        return CreatedAtAction(nameof(Register), new RegistrationResponse(result.Email, result.UserName));
    }
    
    [HttpPost("Login")]
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        
        var result = await _authenticationService.LoginAsync(request.Username, request.Password);

        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }
        Response.Cookies.Append("access_token", result.Token, new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddHours(1)
        });
        return Ok(new AuthResponse(result.Email, result.UserName));
    }
    
    [HttpPost("Logout")]
    public async Task<ActionResult<bool>> Logout()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        Response.Cookies.Delete("access_token");
        
        return Ok(true);
    }
    private void AddErrors(AuthResult result)
    {
        foreach (var error in result.ErrorMessages)
        {
            ModelState.AddModelError(error.Key, error.Value);
        }
    }


}