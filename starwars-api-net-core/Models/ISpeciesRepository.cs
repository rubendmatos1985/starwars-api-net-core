using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
  public interface ISpeciesRepository
  {
    Task<Specie> GetById(Guid id);
    IEnumerable<Specie> Species { get; }
    Task<bool> Add(Specie specie);
  }

}
