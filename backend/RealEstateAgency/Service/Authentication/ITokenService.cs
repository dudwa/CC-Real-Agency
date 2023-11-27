using RealEstateAgency.Service.Authentication.IdentityExtension;

namespace RealEstateAgency.Service.Authentication;

public interface ITokenService
{
    public string CreateToken(ApplicationUser user);
}