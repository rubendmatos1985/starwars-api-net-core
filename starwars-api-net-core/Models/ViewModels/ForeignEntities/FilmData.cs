using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models.ViewModels.ForeignEntities
{
  #nullable enable
  public class FilmData
  {
    public Guid Id { get; set; }
    public string? Title { get; set; }
  }
}
