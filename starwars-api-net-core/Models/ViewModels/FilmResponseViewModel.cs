using starwars_api_net_core.Models.ViewModels.ForeignEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models.ViewModels
{
    public class FilmResponseViewModel
    {
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<PeopleData> Characters { get; set; }

        public IEnumerable<PlanetData> Planets { get; set; }
        public IEnumerable<TransportData> Starships { get; set; }
        public IEnumerable<TransportData> Vehicles { get; set; }
        public IEnumerable<SpecieData> Species { get; set; }
    }
}
