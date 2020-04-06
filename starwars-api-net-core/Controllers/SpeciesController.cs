using Microsoft.AspNetCore.Mvc;
using starwars_api_net_core.Models;
using starwars_api_net_core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable

namespace starwars_api_net_core.Controllers
{
  [Route("species")]
  public class SpeciesController : ControllerBase
  {
    ISpeciesRepository _speciesRepository;
    StarwarsContext _context;

    public SpeciesController(ISpeciesRepository speciesRepository, StarwarsContext ctx)
    {
      _speciesRepository = speciesRepository;
      _context = ctx;
    }

    [Route("")]
    public async Task<IActionResult> Get([FromQuery]Guid? Id, [FromQuery] string? Name)
    {
      if (Id != null)
      {
        var result = await _speciesRepository.GetById((Guid)Id);
        return Ok(new { status = "success", data = result });
      }

      if (Name != null)
      {
        var result = await _speciesRepository.GetByName(Name);
        return Ok(new { status = "success", data = result });
      }
      return Ok(new { status = "error", data = "Not Found" });
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] SpecieResponseViewModel specie)
    {
      var (Name, Classification, Designation, AverageHeight, SkinColors, EyeColors, HairColors, AverageLifespan, Homeworld, Language, People, Films) = specie;
      var newSpecie = new Specie
      {
        Name = Name,
        Classification = Classification,
        Designation = Designation,
        AverageHeight = AverageHeight,
        SkinColors = SkinColors,
        EyeColors = EyeColors,
        HairColors = HairColors,
        AverageLifespan = AverageLifespan,
        Language = Language
      };

      if (Homeworld != null)
      {
        var specieHomeworld = new Planet { Id = Homeworld.Id };
        _context.Planets.Attach(specieHomeworld);
        newSpecie.Homeworld = specieHomeworld;
      };

      if (Films != null)
      {
        var specieFilms = Films.Select(f => new FilmSpecie { FilmId = f.Id, SpecieId = newSpecie.Id }).ToList();
        newSpecie.Films = specieFilms;
      }

      var specieAdded = await _speciesRepository.Add(newSpecie);
      if (specieAdded)
      {
        return RedirectToAction(nameof(Get), new { Id = newSpecie.Id });
      }
      return Ok(new { status = "error", data = "error adding specie" });
    }
  }
}
