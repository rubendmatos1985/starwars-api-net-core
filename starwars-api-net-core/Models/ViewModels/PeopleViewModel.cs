using starwars_api_net_core.Models.ViewModels.ForeignEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace starwars_api_net_core.Models.ViewModels
{
  public class PeopleViewModel
  {
    public Guid? Id;

    [Required]
    public string Name { get; set; }

    [Required]
    public double Height { get; set; }

    [Required]
    public int Mass { get; set; }

    [Required]
    public string HairColor { get; set; }

    [Required]
    public string SkinColor { get; set; }

    [Required]
    public string EyeColor { get; set; }

    [Required]
    public string BirthYear { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    public PlanetData? HomeWorld { get; set; }

    public IEnumerable<FilmData>? Films { get; set; }

    public IEnumerable<VehicleData> Vehicles { get; set; }

    public Specie? Specie { get; set; }

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
      out IEnumerable<VehicleData> vehicles
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
    }

  }
}
