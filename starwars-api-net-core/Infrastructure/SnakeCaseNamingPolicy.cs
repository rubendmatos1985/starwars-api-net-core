using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace starwars_api_net_core.Infrastructure
{
  public class SnakeCaseNamingPolicy : JsonNamingPolicy
  {

    private readonly SnakeCaseNamingStrategy _snakeCaseNamingStrategy = new SnakeCaseNamingStrategy();

    public override string ConvertName(string name)
    {
      return _snakeCaseNamingStrategy.GetPropertyName(name, false);
    }
  }
}
