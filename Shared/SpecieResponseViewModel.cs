using Shared.ForeignEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace Shared
{
    public class SpecieResponseViewModel
    {
        public Guid? Id { get; set; }
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
        public IEnumerable<PeopleData>? People { get; set; }
        public ICollection<FilmData>? Films { get; set; }

        public void Deconstruct(
          out string name,
          out string classif,
          out string des,
          out int avgH,
          out string skinC,
          out string eyeC,
          out string hairC,
          out int avgLife,
          out Planet home,
          out string lang,
          out IEnumerable<PeopleData>? peopD,
          out IEnumerable<FilmData>? filmD
          )
        {
            name = Name;
            classif = Classification;
            des = Designation;
            avgH = AverageHeight;
            skinC = SkinColors;
            eyeC = EyeColors;
            hairC = HairColors;
            avgLife = AverageLifespan;
            home = Homeworld;
            lang = Language;
            peopD = People;
            filmD = Films;
        }
    }
}
