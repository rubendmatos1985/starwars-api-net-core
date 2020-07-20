using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public class PeopleFilms
    {
        public Guid PeopleId { get; set; }
        public People People { get; set; }

        public Guid FilmId { get; set; }
        public Film Film { get; set; }
    }
}
