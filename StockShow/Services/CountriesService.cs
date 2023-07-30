using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;

public class CountriesService : ICountriesService
{
    CountryResponse ICountriesService.AddCountry(CountryAddRequest? CountryAddRequest)
    {
        throw new NotImplementedException();
    }
}
