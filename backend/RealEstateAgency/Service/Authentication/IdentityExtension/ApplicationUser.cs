using Microsoft.AspNetCore.Identity;

namespace RealEstateAgency.Service.Authentication.IdentityExtension;

public class ApplicationUser : IdentityUser
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}