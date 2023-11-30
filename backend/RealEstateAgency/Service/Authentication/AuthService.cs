using Microsoft.AspNetCore.Identity;
using RealEstateAgency.Service.Authentication.IdentityExtension;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RealEstateAgency.Service.Authentication;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<AuthResult> RegisterAsync(string email, string username, string password, string phonenumber,
        string firstname, string lastname, string role)
    {
        var user = new ApplicationUser
        {
            UserName = username,
            Email = email,
            PhoneNumber = phonenumber,
            Firstname = firstname,
            Lastname = lastname
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            return FailedRegistration(result, email, username);
        }

        await _userManager.AddToRoleAsync(user, role);
        return new AuthResult(true, email, username, "");
    }

    private static AuthResult FailedRegistration(IdentityResult result, string email, string username)
    {
        var authResult = new AuthResult(false, email, username, "");

        foreach (var error in result.Errors)
        {
            authResult.ErrorMessages.Add(error.Code, error.Description);
        }

        return authResult;
    }

    public async Task<AuthResult> LoginAsync(string username, string password)
    {
        var managedUser = await _userManager.FindByNameAsync(username);

        if (managedUser == null)
        {
            return InvalidUsername(username);
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, password);
        if (!isPasswordValid)
        {
            return InvalidPassword(username, managedUser.UserName);
        }


        // get the role and pass it to the TokenService
        var roles = await _userManager.GetRolesAsync(managedUser);
        var accessToken = _tokenService.CreateToken(managedUser, roles[0]);

        return new AuthResult(true, managedUser.Email, managedUser.UserName, accessToken);
    }


    private static AuthResult InvalidUsername(string username)
    {
        var result = new AuthResult(false, "", username, "");
        result.ErrorMessages.Add("Bad credentials", "Invalid username");
        return result;
    }

    private static AuthResult InvalidPassword(string email, string userName)
    {
        var result = new AuthResult(false, email, userName, "");
        result.ErrorMessages.Add("Bad credentials", "Invalid password");
        return result;
    }
}