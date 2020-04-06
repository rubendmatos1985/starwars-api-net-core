using System;

namespace starwars_api_net_core.Models
{
  public class FilmSpecie
  {
    public Guid FilmId { get; set; }
    public Film Film { get; set; }

    public Guid SpecieId { get; set; }
    public Specie Specie { get; set; }
  }
}
