using starwars_api_net_core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
  public enum Gender
  {
    Male,
    Female
  }
  public interface IPeopleRepository
  {
    Task<List<PeopleResponseViewModel>> GetById(Guid id);
    Task<List<PeopleResponseViewModel>> GetByName(string name);
    Task<List<PeopleResponseViewModel>> GetByGender(string gender);
    Task<bool> Add(People people);
    Task<bool> AddFilms(People people, IEnumerable<Guid> filmIds);
  }
}
