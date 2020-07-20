using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace Shared
{
    public class People
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Height { get; set; }

        public int Mass { get; set; }

        public string HairColor { get; set; }

        public string SkinColor { get; set; }

        public string EyeColor { get; set; }

        public string BirthYear { get; set; }

        public string Gender { get; set; }

        public Specie? Specie { get; set; }


        public virtual Planet? HomeWorld { get; set; }

        public ICollection<PeopleFilms>? Films { get; set; }

        public ICollection<VehiclePilot>? Vehicles { get; set; }
    }
}
