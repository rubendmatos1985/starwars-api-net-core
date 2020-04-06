using System;

namespace starwars_api_net_core.Models
{
  public class FilmPlanet
  {
    
    public Guid FilmId { get; set; }
    public Film Film { get; set; }

    public Guid PlanetId { get; set; }
    public Planet Planet { get; set; }
  }
}