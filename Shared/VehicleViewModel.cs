using Shared.ForeignEntities;
using System;
using System.Collections.Generic;


#nullable enable
namespace Shared
{
    public class VehicleViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public double? CostInCredits { get; set; }
        public float Length { get; set; }
        public int MaxAtmospheringSpeed { get; set; }
        public int Crew { get; set; }
        public int Passengers { get; set; }
        public int CargoCapacity { get; set; }
        public string? Consumables { get; set; }
        public string VehicleClass { get; set; }
        public IEnumerable<PeopleData>? Pilots { get; set; }
        public IEnumerable<FilmData>? Films { get; set; }

        public void Deconstruct(
          out Guid? id,
          out string name,
          out string model,
          out string manuf,
          out double? cost,
          out float length,
          out int maxAS,
          out int crew,
          out int pass,
          out int cargo,
          out string? cons,
          out string vehicle,
          out IEnumerable<PeopleData>? pilots,
          out IEnumerable<FilmData>? films
         )
        {
            id = Id;
            name = Name;
            model = Model;
            manuf = Manufacturer;
            cost = CostInCredits;
            length = Length;
            maxAS = MaxAtmospheringSpeed;
            crew = Crew;
            pass = Passengers;
            cargo = CargoCapacity;
            cons = Consumables;
            vehicle = VehicleClass;
            pilots = Pilots;
            films = Films;
        }
    }
}

