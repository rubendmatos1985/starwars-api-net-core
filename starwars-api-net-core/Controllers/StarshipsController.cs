using Microsoft.AspNetCore.Mvc;
using starwars_api_net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace starwars_api_net_core.Controllers
{	
	[Route("starships")]
	public class StarshipsController : ControllerBase
	{
		IStarshipsRepository _repository;

		public StarshipsController(IStarshipsRepository repo)
		{
			_repository = repo;
		}

		[Route("")]
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] Guid? id, [FromQuery] string? name)
		{
			if (id != null)
			{
				var starship = await _repository.GetById((Guid)id);
				return Ok(starship);
			}
			if(name != null)
			{
				var starship = await _repository.GetByName(name);
				return Ok(starship);
			}

			var allStarships = await _repository.Starships;
			return Ok(allStarships);
		}
	}
}
