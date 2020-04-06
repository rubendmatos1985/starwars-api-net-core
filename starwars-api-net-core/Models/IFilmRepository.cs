using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
  public interface IFilmRepository
  {
    Task<List<Film>> Films { get; }

    Task<Film> GetById(Guid id);

    Task<Film> GetByTitle(string name);

    Task<Film> GetByEpisode(int episode);

    Task<bool> Add(Film film);
  }
}