using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Shared;
using Shared.ForeignEntities;

namespace starwars_api_net_core.Models
{
	public class PeopleRepository : IPeopleRepository
	{
		private StarwarsContext _context;
		private ILogger<PeopleRepository> _logger;

		public PeopleRepository(StarwarsContext ctxt, ILogger<PeopleRepository> logger)
		{
			_context = ctxt;
			_logger = logger;
		}

		public Task<List<PeopleViewModel>> People => _context.People
		  .Include(p => p.Films)
		  .Include(p => p.HomeWorld)
		  .Include(p => p.Specie)
		  .Include(p => p.Vehicles)
		  .Select(p => new PeopleViewModel
		  {
			  Id = p.Id,
			  Name = p.Name,
			  Films = p.Films.Select(pf => new FilmData { Id = pf.FilmId, Title = pf.Film.Title }),
			  Vehicles = p.Vehicles.Select(pv => new VehicleData { Id = pv.VehicleId, Name = pv.Vehicle.Name }),
			  BirthYear = p.BirthYear,
			  EyeColor = p.EyeColor,
			  Gender = p.Gender,
			  HairColor = p.HairColor,
			  Height = p.Height,
			  HomeWorld = new PlanetData { Id = p.HomeWorld.Id, Name = p.HomeWorld.Name },
			  Mass = p.Mass,
			  SkinColor = p.SkinColor,
			  Specie = new SpecieData { Id = p.Specie.Id, Name = p.Specie.Name }

		  })
		  .AsNoTracking()
		  .ToListAsync();



		public async Task<AddEntityResponse<People>> Add(PeopleViewModel people)
		{
			var (Name, Height, Mass, HairColor, SkinColor, EyeColor, BirthYear, Gender, HomeWorld, Films, Vehicles, Specie) = people;
			var newPeople = new People
			{
				Name = Name,
				Height = Height,
				Mass = Mass,
				HairColor = HairColor,
				SkinColor = SkinColor,
				EyeColor = EyeColor,
				BirthYear = BirthYear,
				Gender = Gender
			};

			if (Films != null)
			{
				var peopleFilms = Films.Select(film => new PeopleFilms { FilmId = film.Id, PeopleId = newPeople.Id }).ToList();
				newPeople.Films = peopleFilms;
			}

			if (HomeWorld != null)
			{
				var peopleHomeworld = new Planet { Id = HomeWorld.Id };
				_context.Planets.Attach(peopleHomeworld);
				newPeople.HomeWorld = peopleHomeworld;
			}
			if (Vehicles != null)
			{
				var peopleVehicles = Vehicles.Select(v => new VehiclePilot { PeopleId = newPeople.Id, VehicleId = v.Id }).ToList();
				newPeople.Vehicles = peopleVehicles;
			}

			if (Specie != null)
			{
				var peopleSpecie = new Specie { Id = people.Specie.Id };
				_context.Species.Attach(peopleSpecie);
				newPeople.Specie = peopleSpecie;
			}

			try
			{
				await _context.People.AddAsync(newPeople).ConfigureAwait(false);
				await _context.SaveChangesAsync().ConfigureAwait(false);
				return new AddEntityResponse<People> { EntitySuccessfullyAdded = true, Entity = newPeople };
			}

			catch (DbUpdateException ex)
			{
				_logger.LogInformation($"PeopleRpository::Add -> { ex.Message }");
				return new AddEntityResponse<People> { EntitySuccessfullyAdded = false, Entity = newPeople };
			}

		}

		public Task<List<PeopleViewModel>> GetByGender(string gender) =>
		  _context.People
			.Include(p => p.HomeWorld)
			.Include(p => p.Films)
			  .ThenInclude(pf => pf.Film)
			.Include(p => p.Vehicles)
			  .ThenInclude(vp => vp.Vehicle)
			.Where(p => p.Gender == gender)
			.Select(p => new PeopleViewModel
			{
				Id = p.Id,
				Name = p.Name,
				BirthYear = p.BirthYear,
				EyeColor = p.EyeColor,
				Gender = p.Gender,
				HairColor = p.HairColor,
				Height = p.Height,
				HomeWorld = new PlanetData { Id = p.HomeWorld.Id, Name = p.Name },
				Mass = p.Mass,
				SkinColor = p.SkinColor,
				Films = p.Films.Select(pf => new FilmData { Id = pf.Film.Id, Title = pf.Film.Title }),
				Vehicles = p.Vehicles.Select(vp => new VehicleData { Id = vp.Vehicle.Id, Name = vp.Vehicle.Name })
			})
			.AsNoTracking()
			.ToListAsync();


		public Task<List<PeopleViewModel>> GetById(Guid id) =>
		  _context.People
			.Include(p => p.HomeWorld)
			.Include(p => p.Films)
			.Include(p => p.Vehicles)
			.Include(p => p.Specie)
			.Where(p => p.Id == id)
			.Select(p => new PeopleViewModel
			{
				Id = p.Id,
				Name = p.Name,
				BirthYear = p.BirthYear,
				EyeColor = p.EyeColor,
				Gender = p.Gender,
				HairColor = p.HairColor,
				Height = p.Height,
				HomeWorld = new PlanetData { Id = p.HomeWorld.Id, Name = p.HomeWorld.Name },
				Mass = p.Mass,
				SkinColor = p.SkinColor,
				Films = p.Films.Select(pf => new FilmData { Id = pf.Film.Id, Title = pf.Film.Title }),
				Vehicles = p.Vehicles.Select(vp => new VehicleData { Id = vp.Vehicle.Id, Name = vp.Vehicle.Name }),
				Specie = new SpecieData { Id = p.Specie.Id, Name = p.Specie.Name }
			})
			.AsNoTracking()
			.ToListAsync();




		public Task<List<PeopleViewModel>> GetByName(string name) =>
		  _context.People
			.Include(p => p.Films)
			.ThenInclude(pf => pf.Film)
			.Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
			.Select(p => new PeopleViewModel
			{
				Id = p.Id,
				Name = p.Name,
				BirthYear = p.BirthYear,
				EyeColor = p.EyeColor,
				Gender = p.Gender,
				HairColor = p.HairColor,
				Height = p.Height,
				HomeWorld = new PlanetData { Id = p.HomeWorld.Id, Name = p.Name },
				Mass = p.Mass,
				SkinColor = p.SkinColor,
				Films = p.Films.Select(pf => new FilmData { Id = pf.Film.Id, Title = pf.Film.Title })
			})
			.AsNoTracking()
			.ToListAsync();

		public async Task<RemoveEntityResponse<People>> Remove(People people)
		{
			try
			{
				_context.People.Remove(people);
				await _context.SaveChangesAsync();
				return new RemoveEntityResponse<People> { EntitySuccessfullyRemoved = true, Entity = people };
			}
			catch (DbUpdateException ex)
			{
				_logger.LogError(ex.Message);
				return new RemoveEntityResponse<People> { EntitySuccessfullyRemoved = false, Entity = people };
			}
		}
	}
}