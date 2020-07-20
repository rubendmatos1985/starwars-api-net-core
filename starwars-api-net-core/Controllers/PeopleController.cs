using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared;
using starwars_api_net_core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace starwars_api_net_core.Controllers
{
	[Route("people")]
	public class PeopleController : ControllerBase
	{
		private IPeopleRepository _peopleRepository;
		private ILogger<PeopleController> _logger;


		public PeopleController(IPeopleRepository pRepo, ILogger<PeopleController> logger)
		{
			_peopleRepository = pRepo;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] Guid? id, [FromQuery] string? gender, [FromQuery] string? name)
		{

			if (id != null)
			{
				var people = await _peopleRepository.GetById((Guid)id);
				return Ok(people);
			}
			if (gender != null)
			{
				var result = await _peopleRepository.GetByGender(gender);
				return Ok(result);
			}
			if (name != null)
			{
				var result = await _peopleRepository.GetByName(name);
				return Ok(result);
			}
			var peopleList = await _peopleRepository.People;
			return Ok(peopleList);
		}

		[HttpPost]
		[Route("add")]
		public async Task<IActionResult> Add([FromBody] PeopleViewModel people)
		{

			AddEntityResponse<People> newPeopleAdded = await _peopleRepository.Add(people);

			if (newPeopleAdded.EntitySuccessfullyAdded)
			{
				return RedirectToAction(nameof(Get), new { newPeopleAdded.Entity.Id });
			}


			return Ok(new { status = "error", message = "add people failed" });
		}

		[HttpPost]
		[Route("remove")]
		public async Task<IActionResult> Remove([FromBody] People people)
		{
			var (successfully, entity) = await _peopleRepository.Remove(people);
			if (successfully)
			{
				return Ok(new { status = "Success", Data = $"Object {entity} successfully removed" });
			}
			else
			{
				return Ok(new { status = "Error", Data = "Operation failed" });
			}

		}

	}

}


