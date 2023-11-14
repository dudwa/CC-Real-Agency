using RealEstateAgency.Model;

namespace RealEstateAgency.Data;

public class Property
{
    public uint Id { get; init; }
    public uint UserId { get; init; }
    public PropertyType Type { get; init; }
    public string City { get; init; }
    public string Adress { get; init; }
    public decimal Value { get; init; }
    public int GroundSpace { get; init; }
    public int BuildYear { get; init; }
    public string About { get; init; }
    public DateTime SubmitDate { get; init; }
}