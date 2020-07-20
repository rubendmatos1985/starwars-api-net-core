using Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
	public interface IStarshipsRepository
	{
		Task<List<Starship>> Starships { get; }

		Task<Starship> GetById(Guid Id);
		Task<List<Starship>> GetByName(string name);
	}
}