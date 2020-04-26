using Microsoft.AspNetCore.Mvc;
using starwars_api_net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Controllers
{
	public class StarshipsController : ControllerBase
	{
		IStarshipsRepository _repository;
		public StarshipsController(IStarshipsRepository repo)
		{
			_repository = repo;
		}
	}
}
