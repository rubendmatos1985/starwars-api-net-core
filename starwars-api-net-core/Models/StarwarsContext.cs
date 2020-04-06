using Microsoft.EntityFrameworkCore;
using starwars_api_net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starwars_api_net_core
{
  public class StarwarsContext : DbContext
  {
    public StarwarsContext(DbContextOptions<StarwarsContext> options)
      : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {

      builder.Entity<PeopleFilms>()
        .HasKey(pf => new { pf.FilmId, pf.PeopleId });

      builder.Entity<PeopleFilms>()
        .HasOne(pf => pf.Film)
        .WithMany(f => f.Actors)
        .HasForeignKey(a => a.FilmId);

      builder.Entity<PeopleFilms>()
        .HasOne(pf => pf.People)
        .WithMany(ps => ps.Films)
        .HasForeignKey(fs => fs.PeopleId);

      builder.Entity<FilmPlanet>()
          .HasKey(fp => new { fp.FilmId, fp.PlanetId });

      builder.Entity<FilmPlanet>()
        .HasOne(fp => fp.Film)
        .WithMany(f => f.Planets)
        .HasForeignKey(p => p.FilmId);

      builder.Entity<FilmPlanet>()
        .HasOne(fp => fp.Planet)
        .WithMany(p => p.Films)
        .HasForeignKey(f => f.PlanetId);

      builder.Entity<FilmSpecie>()
        .HasKey(fs => new { fs.FilmId, fs.SpecieId });

      builder.Entity<FilmSpecie>()
        .HasOne(fs => fs.Film)
        .WithMany(f => f.Species)
        .HasForeignKey(s => s.FilmId);
      builder.Entity<FilmSpecie>()
        .HasOne(fs => fs.Specie)
        .WithMany(s => s.Films)
        .HasForeignKey(f => f.SpecieId);


      builder.Entity<VehicleFilm>()
        .HasKey(vf => new { vf.FilmId, vf.VehicleId });

      builder.Entity<VehicleFilm>()
        .HasOne(vf => vf.Film)
        .WithMany(f => f.Vehicles)
        .HasForeignKey(v => v.FilmId);
      builder.Entity<VehicleFilm>()
        .HasOne(vf => vf.Vehicle)
        .WithMany(vf => vf.Films)
        .HasForeignKey(f => f.VehicleId);

      builder.Entity<VehiclePilot>()
        .HasKey(vp => new { vp.VehicleId, vp.PeopleId });
      builder.Entity<VehiclePilot>()
        .HasOne(vp => vp.Vehicle)
        .WithMany(v => v.Pilots)
        .HasForeignKey(p => p.VehicleId);
      builder.Entity<VehiclePilot>()
        .HasOne(vp => vp.People)
        .WithMany(p => p.Vehicles)
        .HasForeignKey(v => v.PeopleId);
  
    }

    public DbSet<People> People { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Specie> Species { get; set; }
  }
}
