using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared;
namespace starwars_api_net_core.Models
{
  public interface IPlanetRepository
  {
    IEnumerable<Planet> Planets { get; }

    Task<bool> Add(Planet planet);
    Task<Planet> GetById(Guid id);
    Task<List<Planet>> GetByName(string name);
  }
}