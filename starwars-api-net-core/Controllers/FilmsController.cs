using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using starwars_api_net_core.Models;
using starwars_api_net_core.Models.ViewModels;

namespace starwars_api_net_core.Controllers
{
	[Route("films")]
	public class FilmsController : ControllerBase
	{

		private readonly ILogger<FilmsController> _logger;
		private IFilmRepository repository;

		public FilmsController(ILogger<FilmsController> logger, IFilmRepository repo)
		{
			_logger = logger;
			repository = repo;
		}

		[HttpGet]
		[Route("")]
		public async Task<List<FilmResponseViewModel>> Get([FromQuery] Guid? id, [FromQuery] string? title, [FromQuery] int? episode)
		{
			_logger.LogInformation("FilmController::Get");

            if (id != null)
            {
                var film = await repository.GetById((Guid)id);
                return new List<FilmResponseViewModel> { film };
            }

            //if (title != null)
            //{
            //	var film = await repository.GetByTitle(title);
            //	return new List<Film> { film };
            //}

            //if (episode != null)
            //{
            //	var film = await repository.GetByEpisode((int)episode);
            //	return new List<Film> { film };
            //}

            return await repository.Films;
		}

		[HttpPost]
		[Route("")]
		public async Task<ActionResult> Add([FromBody] Film film)
		{
			_logger.LogInformation("FilmsController::Add");

			var saved = await repository.Add(film);

			if (saved)
			{
				return RedirectToAction(nameof(Get), new { title = film.Title });
			}

			return Ok(new { Status = "Error", Message = "the object could not be saved" });
		}

	}
}
