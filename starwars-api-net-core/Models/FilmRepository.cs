using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

    public Task<List<Film>> Films => _context.Films.Include(f => f.Actors).ToListAsync();

    public Task<Film> GetById(Guid id) => _context.Films.FindAsync(id).AsTask();


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


