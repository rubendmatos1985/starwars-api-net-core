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
  
    }

    public DbSet<People> People { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<PeopleFilms> PeopleFilms { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Specie> Species { get; set; }
  }
}
