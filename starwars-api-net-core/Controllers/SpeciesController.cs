using Microsoft.AspNetCore.Mvc;
using starwars_api_net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Controllers
{
  [Route("species")]
  public class SpeciesController : ControllerBase
  {
    ISpeciesRepository _speciesRepository;

    public SpeciesController(ISpeciesRepository speciesRepository)
    {
      speciesRepository = _speciesRepository;
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
        var result = await _speciesRepository.GetById((Guid)Id);
        return Ok(new { status = "success", data = result });
      }
      return Ok(new { status = "error", data = "Not Found" });
    }
  }
}
