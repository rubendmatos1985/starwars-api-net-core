using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using starwars_api_net_core.Models.ViewModels;
using starwars_api_net_core.Models.ViewModels.ForeignEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
  public class VehicleRepository : IVehiclesRepository
  {
    StarwarsContext _context;
    ILogger<VehicleRepository> _logger;

    public VehicleRepository(StarwarsContext ctxt, ILogger<VehicleRepository> log)
    {
      _logger = log;
      _context = ctxt;
    }

    public IEnumerable<Vehicle> Vehicles => _context.Vehicles.AsEnumerable();

    public async Task<AddEntityResponse<Vehicle>> Add(VehicleViewModel vehicle)
    {
      var (
        Id,
        Name,
        Model,
        Manufacturer,
        CostInCredits,
        Length,
        MaxAtmosphericSpeed,
        Crew,
        Passengers,
        CargoCapacity,
        Consumables,
        VehicleClass,
        Pilots,
        Films) = vehicle;

      var newVehicle = new Vehicle
      {
        Name = Name,
        Model = Model,
        Manufacturer = Manufacturer,
        CostInCredits = CostInCredits,
        Length = Length,
        MaxAtmosphericSpeed = MaxAtmosphericSpeed,
        Crew = Crew,
        Passengers = Passengers,
        CargoCapacity = CargoCapacity,
        Consumables = Consumables,
        VehicleClass = VehicleClass
      };

      if (Films != null)
      {
        var vehicleFilms = Films.Select(f => new VehicleFilm { FilmId = f.Id, VehicleId = newVehicle.Id }).ToList();
        newVehicle.Films = vehicleFilms;
      }

      if (Pilots != null)
      {
        var vehiclePilots = Pilots.Select(p => new VehiclePilot { VehicleId = newVehicle.Id, PeopleId = (Guid)p.Id }).ToList();
      }

      var result = new AddEntityResponse<Vehicle> { Entity = newVehicle };

      try
      {
        await _context.Vehicles.AddAsync(newVehicle);
        await _context.SaveChangesAsync();
        result.EntitySuccessfullyAdded = true;
        return result;
      }
      catch (Exception err)
      {
        _logger.LogError(err.Message);
        result.EntitySuccessfullyAdded = false;
        return result;
      }
    }

    public Task<List<VehicleViewModel>> GetById(Guid id)
    {
      return _context.Vehicles
        .Include(v => v.Films)
        .Include(v => v.Pilots)
        .Where(v => v.Id == id)
        .Select(v => new VehicleViewModel
        {
          Id = v.Id,
          Name = v.Name,
          Model = v.Model,
          Manufacturer = v.Manufacturer,
          MaxAtmospheringSpeed = (int)v.MaxAtmosphericSpeed,
          Crew = v.Crew,
          Passengers = v.Passengers,
          CargoCapacity = v.CargoCapacity,
          Consumables = v.Consumables,
          VehicleClass = v.VehicleClass,
          Pilots = v.Pilots.Select(pv => new PeopleData { Id = pv.People.Id, Name = pv.People.Name }),
          Films = v.Films.Select(vf => new FilmData { Id = vf.Film.Id, Title = vf.Film.Title }),
          CostInCredits = v.CostInCredits,
          Length = v.Length
        })
        .AsNoTracking()
        .ToListAsync();
    }

    public Task<List<Vehicle>> GetByName(string name)
    {
      return _context.Vehicles.Where(v => EF.Functions.Like(v.Name, $"%{name}%")).ToListAsync();
    }
  }
}
