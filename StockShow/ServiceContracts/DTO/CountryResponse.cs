using Entities;
namespace ServiceContracts.DTO;
/// <summary>
/// DTO class that is used as return type for most of CountriesService methods
/// </summary>
public class CountryResponse
{
    public Guid CountryID { get; set; }
    public string? CountryName { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is CountryResponse other && CountryID == other.CountryID && CountryName == other.CountryName;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public static class CountryExtensions
{
    public static CountryResponse ToCountryResponse(this Country country)
    {
        return new CountryResponse() { CountryName = country.CountryName, CountryID = country.CountryID };
    }
}
