using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using Entities;

namespace StockShowTest;
/// <summary>
/// This is a test for CountriesService Service
/// It has four tests for CountriesService method: public CountryResponse AddCountry(CountryAddRequest){}:
///     1. AddCountry_NullCountry: When CountryAddRequest is null, it should throw ArgumentNullException
///     2. When CountryName is null, it should throw ArgumentException
///     3. When CountryName is duplicate, it should throw ArgumentException
///     4. When CountryAddRequest is valid, it should return a none null CountryResponse 
/// </summary>
public class CountryServiceTest
{
    private readonly ICountriesService _countryService;
    public CountryServiceTest()
    {
        _countryService = new CountriesService();
    }
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
}
