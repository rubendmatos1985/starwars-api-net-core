using Microsoft.EntityFrameworkCore;
using Shared;


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

            builder.Entity<StarshipsFilms>()
                   .HasKey(sf => new { sf.FilmId, sf.StarshipId });
            builder.Entity<StarshipsFilms>()
                   .HasOne(sf => sf.Film)
                   .WithMany(sf => sf.Starships)
                   .HasForeignKey(sf => sf.FilmId);
            builder.Entity<StarshipsFilms>()
                .HasOne(sf => sf.Starship)
                .WithMany(sf => sf.Films)
                .HasForeignKey(sf => sf.StarshipId);
        }

        public DbSet<People> People { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Specie> Species { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Starship> Starship { get; set; }
    }
}
