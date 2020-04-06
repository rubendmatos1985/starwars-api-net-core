using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
  public class VehiclePilot
  {
    public Guid PeopleId { get; set; }
    public People People { get; set; }

    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
  }
}
