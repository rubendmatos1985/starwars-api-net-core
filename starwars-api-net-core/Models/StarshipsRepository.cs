using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
	public class StarshipsRepository : IStarshipsRepository
	{
		StarwarsContext _context;
		public StarshipsRepository(StarwarsContext ctxt) => _context = ctxt;

		public Task<List<Starship>> Starships => _context.Starship.ToListAsync();

		public Task<Starship> GetById(Guid Id) =>
			_context.Starship
				.Where(s => s.Id == Id)
				.FirstOrDefaultAsync();

		public Task<List<Starship>> GetByName(string name) =>
			_context.Starship
				.Where(s => EF.Functions.Like(s.Name, $"%{name}%"))
				.ToListAsync();
	}
}