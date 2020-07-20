using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public class VehicleFilm
    {
        public Guid FilmId { get; set; }
        public Film Film { get; set; }

        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
