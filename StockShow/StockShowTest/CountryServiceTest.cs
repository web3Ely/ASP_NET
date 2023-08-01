using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using Entities;

namespace StockShowTest;
/// <summary>
/// This is a test for CountriesService Service
/// </summary>
public class CountryServiceTest
{
    private readonly ICountriesService _countryService;
    public CountryServiceTest()
    {
        _countryService = new CountriesService();
    }

    #region AddCountry
    /// <summary>
    /// It has four tests for CountriesService method: public CountryResponse AddCountry(CountryAddRequest){}:
    ///     1. AddCountry_NullCountry: When CountryAddRequest is null, it should throw ArgumentNullException
    ///     2. When CountryName is null, it should throw ArgumentException
    ///     3. When CountryName is duplicate, it should throw ArgumentException
    ///     4. When CountryAddRequest is valid, it should return a none null CountryResponse 
    /// </summary>
    [Fact]
    public void AddCountry_NullCountry()
    {
        //Arrange
        CountryAddRequest? req = null;
        //Act
        void act() => _countryService.AddCountry(req);
        //Assert
        Assert.Throws<ArgumentNullException>(act);
    }
    [Fact]
    public void AddCountry_NullCountryName()
    {
        //Arrange
        CountryAddRequest req = new() { CountryName = null };
        //Act
        void act() => _countryService.AddCountry(req);
        //Assert
        Assert.Throws<ArgumentException>(act);
    }
    [Fact]
    public void AddCountry_DuplicateCountryName()
    {
        //Arrange
        CountryAddRequest countryOne = new() { CountryName = "USA" };
        CountryAddRequest countryTwo = new() { CountryName = "USA" };
        //Act
        void act()
        {
            _countryService.AddCountry(countryOne);
            _countryService.AddCountry(countryTwo);
        }
        //Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void AddCountry_ProperCountryDetail()
    {
        //Arrange
        CountryAddRequest country = new() { CountryName = "Japan" };
        //Act
        CountryResponse res = _countryService.AddCountry(country);
        //Assert
        Assert.True(res.CountryID != Guid.Empty);
    }
    #endregion

    #region GetAllCountires
    /// <summary>
    /// It has two tests for CountriesService method: public List<CountryResponse> GetAllCountries (){}:
    ///     1. The list of countires should be empty in the begining  
    ///     2. Correct way of getting list 
    /// </summary>
    [Fact]
    public void GetAllCountires_EmptyList()
    {
        //Arrange
        List<CountryResponse> country_response_list = _countryService.GetAllCountries();

        //Act and Assert
        Assert.Empty(country_response_list);
    }

    [Fact]
    public void GetAllCountries_AddFewCountries()
    {
        //Arrange
        List<CountryAddRequest> country_request_list = new List<CountryAddRequest>() {
            new CountryAddRequest() { CountryName = "USA" },
            new CountryAddRequest() { CountryName = "UK" }
        };

        //Act
        List<CountryResponse> countries_list_from_add_country = new List<CountryResponse>();

        foreach (CountryAddRequest country_request in country_request_list)
        {
            countries_list_from_add_country.Add(_countryService.AddCountry(country_request));
        }

        List<CountryResponse> actualCountryResponseList = _countryService.GetAllCountries();

        //read each element from countries_list_from_add_country
        foreach (CountryResponse expected_country in countries_list_from_add_country)
        {
            Assert.Contains(expected_country, actualCountryResponseList);
        }
    }
    #endregion

}
