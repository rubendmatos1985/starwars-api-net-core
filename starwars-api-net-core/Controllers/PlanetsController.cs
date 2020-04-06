using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using starwars_api_net_core.Models;
using starwars_api_net_core.Models.ViewModels;
using starwars_api_net_core.Models.ViewModels.ForeignEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace starwars_api_net_core.Controllers
{
  [Route("planets")]
  public class PlanetsController : ControllerBase
  {
    private ILogger<PlanetsController> _logger;
    private IPlanetRepository _planetRepository;
    private IFilmRepository _filmRepository;
    private IPeopleRepository _peopleRepository;
    public PlanetsController
    (
      ILogger<PlanetsController> logger,
      IPlanetRepository plRepo,
      IPeopleRepository peopRepo,
      IFilmRepository fRepo
     )
    {
      _logger = logger;
      _planetRepository = plRepo;
      _filmRepository = fRepo;
      _peopleRepository = peopRepo;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Guid? id, [FromQuery] string? name)
    {
      if (id != null)
      {
        return Ok(await _planetRepository.GetById((Guid)id));

      }
      if (name != null)
      {
        return Ok(await _planetRepository.GetByName(name));
      }
      return Ok(new { status = "error", message = "not found" });
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] PlanetResponseViewModel planet)
    {
      var (Name, RotationPeriod, OrbitalPeriod, Diameter, Climate, Gravity, Terrain, SurfaceWater, Population, Residents, Films) = planet;
      var newPlanet = new Planet
      {
        Name = Name,
        RotationPeriod = RotationPeriod,
        OrbitalPeriod = OrbitalPeriod,
        Diameter = Diameter,
        Climate = Climate,
        Gravity = Gravity,
        Terrain = Terrain,
        SurfaceWater = SurfaceWater,
        Population = Population
      };
      if (Films != null)
      {
        var planetFilms = Films.Select(f => new FilmPlanet { PlanetId = newPlanet.Id, FilmId = f.Id }).ToList();
        newPlanet.Films = planetFilms;
      }
      if (Residents != null)
      {
        var planetResidents = Residents.Select(p => new People { Id = p.Id }).ToList();
        newPlanet.Residents = planetResidents;
      }
      bool planetAdded = await _planetRepository.Add(newPlanet);
      if (planetAdded)
      {

        return Ok(new { status = "success", data = "planet added" });
      }
      return Ok(new { status = "error", data = "error adding planet" });
    }
  }
}

