using Shared.ForeignEntities;
using System;
using System.Collections.Generic;

#nullable enable
namespace Shared
{
    public class PeopleViewModel
    {
        public Guid? Id;

        public string Name { get; set; }

        public double Height { get; set; }

        public int Mass { get; set; }

        public string HairColor { get; set; }

        public string SkinColor { get; set; }

        public string EyeColor { get; set; }

        public string BirthYear { get; set; }

        public string Gender { get; set; }

        public PlanetData? HomeWorld { get; set; }


        public IEnumerable<FilmData>? Films { get; set; }

        public IEnumerable<VehicleData> Vehicles { get; set; }

        public SpecieData Specie { get; set; }


        public void Deconstruct(
          out string name,
          out double height,
          out int mass,
          out string hair,
          out string skin,
          out string eyesColor,
          out string birth,
          out string gender,
          out PlanetData? homeworld,
          out IEnumerable<FilmData>? films,
          out IEnumerable<VehicleData> vehicles,
          out SpecieData specie
          )
        {
            name = Name;
            height = Height;
            mass = Mass;
            hair = HairColor;
            skin = SkinColor;
            eyesColor = EyeColor;
            birth = BirthYear;
            gender = Gender;
            homeworld = HomeWorld;
            films = Films;
            vehicles = Vehicles;
            specie = Specie;
        }

    }
}
