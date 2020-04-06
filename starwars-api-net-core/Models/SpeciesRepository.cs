using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
  public class SpeciesRepository : ISpeciesRepository
  {
    private StarwarsContext _context;
    private ILogger<SpeciesRepository> _logger;

    public SpeciesRepository(ILogger<SpeciesRepository> logger, StarwarsContext ctx) { _logger = logger; _context = ctx; }

    public IEnumerable<Specie> Species => _context.Species.ToList();

    public async Task<bool> Add(Specie specie)
    {
      try
      {
        await _context.Species.AddAsync(specie);
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception e)
      {
        _logger.LogInformation(e.Message);
        return false;
      }
    }

    public Task<Specie> GetById(Guid id) =>
      _context.Species
        .FindAsync(id)
        .AsTask();


    public Task<List<Specie>> GetByName(string name) =>
      _context.Species
        .Where(sp => EF.Functions.Like(sp.Name, $"%{name}%"))
        .ToListAsync();

  }
}
