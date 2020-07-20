using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public class Specie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public int AverageHeight { get; set; }
        public string SkinColors { get; set; }
        public string EyeColors { get; set; }
        public string HairColors { get; set; }
        public int AverageLifespan { get; set; }
        public Planet Homeworld { get; set; }
        public string Language { get; set; }
        public IEnumerable<People> People { get; set; }
        public ICollection<FilmSpecie> Films { get; set; }
    }
}
