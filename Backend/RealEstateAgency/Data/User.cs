using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RealEstateAgency.Model;

namespace RealEstateAgency.Data;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public string Username { get; init; } 
    public string Password { get; set; } 
    public string Surname { get; init; }
    public string Firstname { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public RoleType Role { get; init; }
    public bool IsDeleted { get; init; }

 }