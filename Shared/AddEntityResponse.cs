using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public class AddEntityResponse<T>
    {
        public bool EntitySuccessfullyAdded { get; set; }
        public T Entity { get; set; }

        public void Deconstruct(out bool entSuccc, out T entity)
        {
            entity = Entity;
            entSuccc = EntitySuccessfullyAdded;
        }
    }
}
