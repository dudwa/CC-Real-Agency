using RealEstateAgency.Model;

namespace RealEstateAgency.Data;

public class User
{
    public uint UserId { get; init; }
    public string Username { get; init; } 
    public string Password { get; init; } 
    public string Surname { get; init; }
    public string Firstname { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public RoleType Role { get; init; }
}