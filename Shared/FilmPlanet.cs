using System;

namespace Shared
{
    public class FilmPlanet
    {

        public Guid FilmId { get; set; }
        public Film Film { get; set; }

        public Guid PlanetId { get; set; }
        public Planet Planet { get; set; }
    }
}