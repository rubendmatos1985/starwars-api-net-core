using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable enable
namespace starwars_api_net_core.Models
{
  public class Film
  {
    public Guid Id{ get; set; }
    
    [Required]
    public string Title{ get; set; }
    
    [Required]
    public int Episode { get; set; }
    
    [Required]
    public string OpeningCrawl { get; set; }
    
    [Required]
    public string Director{ get; set; }
    
    [Required]
    public string Producer{ get; set; }
    
    [Required]
    public DateTime ReleaseDate{ get; set; }

    public ICollection<PeopleFilms> Actors{ get; set; }

    public ICollection<FilmPlanet>? Planets { get; set; }

    public ICollection<FilmSpecie>? Species { get; set; }

    public ICollection<VehicleFilm>? Vehicles { get; set; }

  }
}
