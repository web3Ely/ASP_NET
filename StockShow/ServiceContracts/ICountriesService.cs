using ServiceContracts.DTO;

namespace ServiceContracts;
/// <summary>
/// Represent business logic for manipulating Country entity
/// </summary>
public interface ICountriesService
{
    /// <summary>
    /// Adds a country object to the list of countries
    /// </summary>
    /// <param name="CountryADDRequest">Country object to add</param>
    /// <returns>returns the country object after adding it including country id</returns>
    public CountryResponse AddCountry(CountryAddRequest? CountryAddRequest);

    /// <summary>
    /// Returns all countries from the list
    /// </summary>
    /// <returns>All counties from the list as list of CountryResponse</returns>
    public List<CountryResponse> GetAllCountries();
}
