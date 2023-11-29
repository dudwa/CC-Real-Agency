using RealEstateAgency.Service.Authentication.IdentityExtension;

namespace RealEstateAgency.Service.Authentication;

public interface ITokenService
{
    string CreateToken(ApplicationUser user, string role);
}