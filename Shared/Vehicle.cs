using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace Shared
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public double? CostInCredits { get; set; }
        public float Length { get; set; }
        public double MaxAtmosphericSpeed { get; set; }
        public int Crew { get; set; }
        public int Passengers { get; set; }
        public int CargoCapacity { get; set; }
        public string? Consumables { get; set; }
        public string VehicleClass { get; set; }
        public ICollection<VehiclePilot> Pilots { get; set; }
        public ICollection<VehicleFilm> Films { get; set; }
    }
}
