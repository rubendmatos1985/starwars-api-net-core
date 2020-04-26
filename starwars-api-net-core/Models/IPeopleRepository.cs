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
    Task<List<PeopleViewModel>> People { get; }
    Task<List<PeopleViewModel>> GetById(Guid id);
    Task<List<PeopleViewModel>> GetByName(string name);
    Task<List<PeopleViewModel>> GetByGender(string gender);
    Task<AddEntityResponse<People>> Add(PeopleViewModel people);
  }
}
