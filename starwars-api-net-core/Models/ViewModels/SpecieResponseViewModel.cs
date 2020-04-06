using starwars_api_net_core.Models.ViewModels.ForeignEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace starwars_api_net_core.Models.ViewModels
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
  }
}
