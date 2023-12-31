﻿using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace StockShow;

public class PersonsController : Controller
{
    //private fields
    // private readonly IPersonsService _personsService;

    // //constructor
    // public PersonsController(IPersonsService personsService)
    // {
    //     _personsService = personsService;
    // }

    [Route("persons/index")]
    [Route("/")]
    public IActionResult Index()
    {
        // List<PersonResponse> persons = _personsService.GetAllPersons();

        return View(); //Views/Persons/Index.cshtml(Same name with this method)
    }
}
