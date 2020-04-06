using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using starwars_api_net_core.Models;
using starwars_api_net_core.Models.ViewModels;
using starwars_api_net_core.Models.ViewModels.ForeignEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
#nullable enable
namespace starwars_api_net_core.Controllers
{
  [Route("people")]
  public class PeopleController : ControllerBase
  {
    private IPeopleRepository _peopleRepository;
    private IFilmRepository _filmRepository;
    private ILogger<PeopleController> _logger;
    private IPlanetRepository _planetRepository;
    public PeopleController(
      IPeopleRepository pRepo,
      IFilmRepository fRepo,
      IPlanetRepository plRepo,
      ILogger<PeopleController> logger
     )
    {
      _peopleRepository = pRepo;
      _filmRepository = fRepo;
      _logger = logger;
      _planetRepository = plRepo;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Guid? id, [FromQuery] string? gender, [FromQuery] string? name)
    {

      if (id != null)
      {
        var people = await _peopleRepository.GetById((Guid)id);
        return Ok(people);
      }
      if (gender != null)
      {
        var result = await _peopleRepository.GetByGender(gender);
        return Ok(result);
      }
      if (name != null)
      {
        var result = await _peopleRepository.GetByName(name);
        return Ok(result);
      }

      IEnumerable<People> emptyPeople = new[] { new People { } };
      return Ok(emptyPeople);
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody]PeopleResponseViewModel people)
    {
      var (Name, Height, Mass, HairColor, SkinColor, EyeColor, BirthYear, Gender, HomeWorld, Films) = people;
      var newPeople = new People
      {
        Name = Name,
        Height = Height,
        Mass = Mass,
        HairColor = HairColor,
        SkinColor = SkinColor,
        EyeColor = EyeColor,
        BirthYear = BirthYear,
        Gender = Gender
      };


      if (Films != null)
      {
        var peopleFilms = people.Films.Select(film => new PeopleFilms { FilmId = film.Id, PeopleId = newPeople.Id }).ToList();
        newPeople.Films = peopleFilms;
      }


      if (HomeWorld != null)
      {
        newPeople.HomeWorld = await _planetRepository.GetById(HomeWorld.Id);
      }

      bool newPeopleAdded = await _peopleRepository.Add(newPeople);

      if (newPeopleAdded)
      {
        return RedirectToAction(nameof(Get), new { Id = newPeople.Id });
      }


      return Ok(new { status = "error", message = "add people failed" });
    }

  }

}


