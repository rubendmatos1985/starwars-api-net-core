using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core.Models
{
	public class StarshipsFilms
	{
		public Guid StarshipId { get; set; }
		public Starship Starship { get; set; }

		public Guid FilmId { get; set; }
		public Film Film { get; set; }
	}
}
