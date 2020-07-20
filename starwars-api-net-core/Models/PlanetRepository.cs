using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace starwars_api_net_core.Models
{
	public class PlanetRepository : IPlanetRepository
	{
		private StarwarsContext _context;
		private ILogger<StarwarsContext> _logger;

		public PlanetRepository(StarwarsContext ctx, ILogger<StarwarsContext> logger)
		{
			_context = ctx; _logger = logger;
		}

		public IEnumerable<Planet> Planets => _context.Planets.ToList();

		public Task<Planet> GetById(Guid id) =>
		  _context.Planets.FindAsync(id).AsTask();


		public async Task<bool> Add(Planet planet)
		{
			try
			{
				await _context.Planets.AddAsync(planet).ConfigureAwait(false);
				await _context.SaveChangesAsync().ConfigureAwait(false);
				return true;
			}
			catch (DbUpdateException ex)
			{
				_logger.LogError(ex.Message);
				return false;
			}
		}

		public Task<List<Planet>> GetByName(string name) =>
		  _context.Planets
			.Where(pl => EF.Functions.Like(pl.Name, $"%{name}%"))
			.AsNoTracking()
			.ToListAsync();
	}
}
