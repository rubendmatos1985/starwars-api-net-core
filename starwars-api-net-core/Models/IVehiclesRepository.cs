using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
  public interface IVehiclesRepository
  {
    Task<List<VehicleViewModel>> GetById(Guid id);
    Task<List<Vehicle>> GetByName(string name);
    Task<AddEntityResponse<Vehicle>> Add(VehicleViewModel vehicle);
    IEnumerable<Vehicle> Vehicles { get; }
  }
}
