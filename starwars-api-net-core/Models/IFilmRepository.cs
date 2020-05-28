using starwars_api_net_core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
    public interface IFilmRepository
    {
        Task<List<FilmResponseViewModel>> Films { get; }

        Task<FilmResponseViewModel> GetById(Guid id);

        Task<Film> GetByTitle(string name);

        Task<Film> GetByEpisode(int episode);

        Task<bool> Add(Film film);
    }
}