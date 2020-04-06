using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
  public class VehicleFilm
  {
    public Guid FilmId { get; set; }
    public Film Film { get; set;  }

    public Guid VehicleId { get; set;  }
    public Vehicle Vehicle { get; set; }
  }
}
