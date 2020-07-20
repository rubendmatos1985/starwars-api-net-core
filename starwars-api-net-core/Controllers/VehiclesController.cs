using Microsoft.AspNetCore.Mvc;
using Shared;
using starwars_api_net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace starwars_api_net_core.Controllers
{
  [Route("vehicles")]
  public class VehiclesController : ControllerBase
  {
    IVehiclesRepository _vehiclesRepository;

    public VehiclesController(IVehiclesRepository vehiclesRepo)
    {
      _vehiclesRepository = vehiclesRepo;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> Get([FromQuery] Guid? Id, [FromQuery] string? Name)
    {
      if (Id != null)
      {
        var vehicle = await _vehiclesRepository.GetById((Guid)Id);
        return Ok(new { status = "success", data = vehicle });

      }
      if (Name != null)
      {
        var vehicle = await _vehiclesRepository.GetByName((string)Name);
        return Ok(new { status = "success", data = vehicle });
      }

      return Ok(new { status = "error", data = "Not found" });
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody]VehicleViewModel vehicle)
    {
      var (EntitySuccessfullyAdded, Entity) = await _vehiclesRepository.Add(vehicle);
      if (EntitySuccessfullyAdded)
      {
        return RedirectToAction(nameof(Get), new { Id = Entity.Id });
      }
      return Ok(new { status = "error", data = $"not possible add{vehicle.Name}" });
    }

  }
}
