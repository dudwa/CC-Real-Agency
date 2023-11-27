using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Contracts;

public record RegistrationRequest(
    [Required]string Email, 
    [Required]string Username, 
    [Required]string Password,
    [Required]string PhoneNumber,
    [Required]string Firstname,
    [Required]string Lastname
    );