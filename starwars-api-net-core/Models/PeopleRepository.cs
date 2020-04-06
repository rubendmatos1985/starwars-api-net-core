using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using starwars_api_net_core.Models.ViewModels;
using starwars_api_net_core.Models.ViewModels.ForeignEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

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

    public async Task<AddEntityResponse<People>> Add(PeopleViewModel people)
    {
      var (Name, Height, Mass, HairColor, SkinColor, EyeColor, BirthYear, Gender, HomeWorld, Films) = people;
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
        var peopleFilms = people.Films.Select(film => new PeopleFilms { FilmId = film.Id, PeopleId = newPeople.Id }).ToList();
        newPeople.Films = peopleFilms;
      }

      if (HomeWorld != null)
      {
        var peopleHomeworld = new Planet { Id = HomeWorld.Id };
        _context.Planets.Attach(peopleHomeworld);
        newPeople.HomeWorld = peopleHomeworld;
      }

      try
      {
        await _context.People.AddAsync(newPeople);
        await _context.SaveChangesAsync();
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
          HomeWorld = new PlanetData { Id = p.HomeWorld.Id, Name=p.Name },
          Mass = p.Mass,
          SkinColor = p.SkinColor,
          Films = p.Films.Select(pf => new FilmData { Id = pf.Film.Id, Title = pf.Film.Title })
        })
        .AsNoTracking()
        .ToListAsync();


    public Task<List<PeopleViewModel>> GetById(Guid id) =>
      _context.People
        .Include(p => p.HomeWorld)
        .Include(p => p.Films)
        .ThenInclude(pf => pf.Film)
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
          Films = p.Films.Select(pf => new FilmData { Id = pf.Film.Id, Title = pf.Film.Title })
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

    public async Task<bool> AddFilms(People people, IEnumerable<Guid> filmIds)
    {
      try
      {
        people.Films = filmIds.Select(id => new PeopleFilms { FilmId = id, PeopleId = people.Id }).ToList();
        await _context.SaveChangesAsync();
        return true;
      }
      catch (DbUpdateException ex)
      {
        _logger.LogError($"PeopleRepository::AddFilms -> {ex.Message}");
        return false;
      }

    }
  }
}