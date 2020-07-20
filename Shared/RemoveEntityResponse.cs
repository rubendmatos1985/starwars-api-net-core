using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
	public class RemoveEntityResponse<EntityType>
	{
		public bool EntitySuccessfullyRemoved { get; set; }
		public EntityType Entity { get; set; }

		public void Deconstruct(out bool entitySucc, out EntityType entity)
		{
			entitySucc = EntitySuccessfullyRemoved;
			entity = Entity;
		}
	}
}
