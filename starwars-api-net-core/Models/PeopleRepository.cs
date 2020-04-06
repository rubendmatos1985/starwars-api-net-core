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

    public async Task<bool> Add(People people)
    {
      try
      {
        await _context.People.AddAsync(people);
        await _context.SaveChangesAsync();
        return true;
      }
      catch (DbUpdateException ex)
      {
        _logger.LogInformation($"PeopleRpository::Add -> { ex.Message }");
        return false;
      }

    }

    public Task<List<PeopleResponseViewModel>> GetByGender(string gender) =>
      _context.People
        .Include(p => p.HomeWorld)
        .Include(p => p.Films)
        .ThenInclude(pf => pf.Film)
        .Where(p => p.Gender == gender)
        .Select(p => new PeopleResponseViewModel
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


    public Task<List<PeopleResponseViewModel>> GetById(Guid id) =>
      _context.People
        .Include(p => p.HomeWorld)
        .Include(p => p.Films)
        .ThenInclude(pf => pf.Film)
        .Where(p => p.Id == id)
        .Select(p => new PeopleResponseViewModel
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




    public Task<List<PeopleResponseViewModel>> GetByName(string name) =>
      _context.People
        .Include(p => p.Films)
        .ThenInclude(pf => pf.Film)
        .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
        .Select(p => new PeopleResponseViewModel
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