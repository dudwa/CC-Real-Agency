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

        Console.WriteLine(request.ToString());
        var result = await _authenticationService.LoginAsync(request.Username, request.Password);

        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }

        // Create a new cookie options
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTimeOffset.Now.AddHours(1),
            Domain = "http://localhost:5173"
        };

        // Add the cookie to the response
        Response.Cookies.Append("MyCookie", result.Token, cookieOptions);
        return Ok(new AuthResponse(result.Email, result.UserName));
    }

    private void AddErrors(AuthResult result)
    {
        foreach (var error in result.ErrorMessages)
        {
            ModelState.AddModelError(error.Key, error.Value);
        }
    }


}