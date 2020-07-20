using Shared.ForeignEntities;
using System.Collections.Generic;

#nullable enable
namespace Shared
{
    public class PlanetResponseViewModel
    {
        public string Name { get; set; }
        public int RotationPeriod { get; set; }
        public int OrbitalPeriod { get; set; }
        public double Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public int SurfaceWater { get; set; }
        public double Population { get; set; }
        public IEnumerable<ResidentData>? Residents { get; set; }
        public IEnumerable<FilmData>? Films { get; set; }

        public void Deconstruct(
          out string name,
          out int rotationPeriod,
          out int orbitalPeriod,
          out double diameter,
          out string climate,
          out string grav,
          out string terr,
          out int sw,
          out double pop,
          out IEnumerable<ResidentData> res,
          out IEnumerable<FilmData> fd
         )
        {
            name = Name;
            rotationPeriod = RotationPeriod;
            orbitalPeriod = OrbitalPeriod;
            diameter = Diameter;
            climate = Climate;
            grav = Gravity;
            terr = Terrain;
            sw = SurfaceWater;
            pop = Population;
            res = Residents;
            fd = Films;

        }
    }
}


