using System;
using System.Collections.Generic;

namespace Shared
{
    public class Planet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RotationPeriod { get; set; }
        public int OrbitalPeriod { get; set; }
        public double Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public int SurfaceWater { get; set; }
        public double Population { get; set; }
        public ICollection<People> Residents { get; set; }
        public ICollection<FilmPlanet> Films { get; set; }
    }
}
