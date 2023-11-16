using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RealEstateAgency.Model;

namespace RealEstateAgency.Data;

public class RealEstate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public int UserId { get; init; }
    public RealEstateType Type { get; init; }
    public RealEstateStatus Status { get; init; }
    public string City { get; init; }
    public string Address { get; init; }
    public decimal Value { get; set; }
    public int GroundSpace { get; init; }
    public int BuildYear { get; init; }
    public string About { get; set; }
    public DateTime SubmitDate { get; init; }

}