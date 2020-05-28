using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using starwars_api_net_core.Models.ViewModels;
using starwars_api_net_core.Models.ViewModels.ForeignEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
    public class FilmRepository : IFilmRepository
    {
        StarwarsContext _context;
        ILogger<FilmRepository> logger;

        public FilmRepository(StarwarsContext context, ILogger<FilmRepository> log) { _context = context; logger = log; }

        public Task<List<FilmResponseViewModel>> Films =>
            _context.Films
                    .Include(f => f.Actors)
                    .Include(f => f.Planets)
                    .Include(f => f.Starships)
                    .Include(f => f.Vehicles)
                    .Include(f => f.Species)
                    .Select(
                        f => new FilmResponseViewModel
                        {
                            Title = f.Title,
                            EpisodeId = f.Episode,
                            OpeningCrawl = f.OpeningCrawl,
                            Director = f.Director,
                            Producer = f.Producer,
                            ReleaseDate = f.ReleaseDate,
                            Characters = f.Actors.Select(a => new PeopleData { Id = a.PeopleId, Name = a.People.Name }),
                            Planets = f.Planets.Select(fp => new PlanetData { Id = fp.PlanetId, Name = fp.Planet.Name }),
                            Starships = f.Starships.Select(fs => new TransportData { Id = fs.StarshipId, Name = fs.Starship.Name }),
                            Vehicles = f.Vehicles.Select(fv => new TransportData { Id = fv.VehicleId, Name = fv.Vehicle.Name }),
                            Species = f.Species.Select(fs => new SpecieData { Id = fs.SpecieId, Name = fs.Specie.Name })
                        }
                    )
                    .AsNoTracking()
                    .ToListAsync();




        public async Task<FilmResponseViewModel> GetById(Guid id)
        {
            var film = await _context.Films
                     .Include(f => f.Actors)
                        .ThenInclude(fp => fp.People)
                     .Include(f => f.Planets)
                        .ThenInclude(fp => fp.Planet)
                     .Include(f => f.Starships)
                        .ThenInclude(fs => fs.Starship)
                     .Include(f => f.Vehicles)
                        .ThenInclude(fv => fv.Vehicle)
                     .Include(f => f.Species)
                        .ThenInclude(fs => fs.Specie)
                     .FirstOrDefaultAsync(f => f.Id == id);
            return new FilmResponseViewModel
            {
                Title = film.Title,
                EpisodeId = film.Episode,
                OpeningCrawl = film.OpeningCrawl,
                Director = film.Director,
                Producer = film.Producer,
                ReleaseDate = film.ReleaseDate,
                Characters = film.Actors.Select(a => new PeopleData { Id = a.PeopleId, Name = a.People.Name }),
                Planets = film.Planets.Select(fp => new PlanetData { Id = fp.PlanetId, Name = fp.Planet.Name }),
                Starships = film.Starships.Select(fs => new TransportData { Id = fs.StarshipId, Name = fs.Starship.Name }),
                Vehicles = film.Vehicles.Select(fv => new TransportData { Id = fv.VehicleId, Name = fv.Vehicle.Name }),
                Species = film.Species.Select(fs => new SpecieData { Id = fs.SpecieId, Name = fs.Specie.Name })

            };

        }


        public Task<Film> GetByTitle(string title) =>
          _context.Films
            .Where(f => EF.Functions.Like(f.Title, $"%{title}%"))
            .FirstOrDefaultAsync();



        public Task<Film> GetByEpisode(int episode) =>
          _context.Films
            .Where(f => f.Episode == episode)
            .FirstOrDefaultAsync();


        public async Task<bool> Add(Film film)
        {
            _context.Films.Add(film);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException err)
            {
                logger.LogError(err.Message);
                return false;
            }
        }

    }
}


