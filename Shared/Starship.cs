using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
	public class Starship
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public double CostInCredits { get; set; }
		public double Length { get; set; }
		public double MaxAtmospheringSpeed { get; set; }
		public int Crew { get; set; }
		public int Passengers { get; set; }
		public double CargoCapacity { get; set; }
		public string Consumables { get; set; }
		public double HyperdriveRating { get; set; }
		public double MGLT { get; set; }
		public string StarshipClass { get; set; }
		public ICollection<StarshipsFilms> Films{ get; set; }

	}

}
