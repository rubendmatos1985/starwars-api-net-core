using System;
using System.Collections.Generic;


#nullable enable
namespace Shared
{
    public class Film
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int Episode { get; set; }

        public string OpeningCrawl { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<PeopleFilms> Actors { get; set; }

        public ICollection<FilmPlanet>? Planets { get; set; }

        public ICollection<FilmSpecie>? Species { get; set; }

        public ICollection<VehicleFilm>? Vehicles { get; set; }

        public ICollection<StarshipsFilms>? Starships { get; set; }

    }
}
