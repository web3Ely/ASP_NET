using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;

public class CountriesService : ICountriesService
{
    private readonly List<Country> _countries;

    public CountriesService()
    {
        _countries = new List<Country>();
    }

    public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
    {
        //Validate if CountryAddRequest is null
        if (countryAddRequest == null)
        {
            throw new ArgumentNullException(nameof(CountryAddRequest));
        }
        //Validate if CountryName is null
        if (countryAddRequest.CountryName == null)
        {
            throw new ArgumentException(nameof(CountryAddRequest.CountryName));
        }
        //Validate if it is a duplicate country
        if (_countries.Where((listed) => listed.CountryName == countryAddRequest.CountryName).Count() > 0)
        {
            throw new ArgumentException("Given Country Name alread exist");
        }

        Country country = countryAddRequest.ToCountry();
        country.CountryID = Guid.NewGuid();

        _countries.Add(country);

        return country.ToCountryResponse();
    }

    public List<CountryResponse> GetAllCountries()
    {
        return _countries.Select(country => country.ToCountryResponse()).ToList();
    }

    public CountryResponse? GetCountryByCountryID(Guid? countryID)
    {
        if (countryID == null)
        {
            return null;
        }
        Country? country = _countries.FirstOrDefault(temp => temp.CountryID == countryID);
        if (country == null)
        {
            return null;
        }
        return country.ToCountryResponse();
    }
}
