using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;
namespace StockShowTest;

public class PersonServiceTest
{
    //private fields
    private readonly IPersonsService _personService;


    //constructor
    public PersonServiceTest()
    {
        _personService = new PersonsService();
    }

    #region AddPerson

    //When we supply null value as PersonAddRequest, it should throw ArgumentNullException
    [Fact]
    public void AddPerson_NullPerson()
    {
        //Arrange
        PersonAddRequest? personAddRequest = null;

        //Act
        PersonResponse act() => _personService.AddPerson(personAddRequest);

        //Assert
        Assert.Throws<ArgumentNullException>(act);
    }


    //When we supply null value as PersonName, it should throw ArgumentException
    [Fact]
    public void AddPerson_PersonNameIsNull()
    {
        //Arrange
        PersonAddRequest? personAddRequest = new() { PersonName = null };

        //Act
        PersonResponse act() => _personService.AddPerson(personAddRequest);
        //Assert
        Assert.Throws<ArgumentException>(act);
    }

    //When we supply proper person details, it should insert the person into the persons list; and it should return an object of PersonResponse, which includes with the newly generated person id
    [Fact]
    public void AddPerson_ProperPersonDetails()
    {
        //Arrange
        PersonAddRequest? personAddRequest = new() { PersonName = "My name", Email = "hahaha@example.com", Address = "sample address", CountryID = Guid.NewGuid(), Gender = GenderOptions.Male, DateOfBirth = DateTime.Parse("2000-01-01"), ReceiveNewsLetters = true };

        //Act
        PersonResponse person_response_from_add = _personService.AddPerson(personAddRequest);


        //Assert
        Assert.True(person_response_from_add.PersonID != Guid.Empty);

    }

    #endregion
}

