﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using starwars_api_net_core;

namespace starwars_api_net_core.Migrations
{
    [DbContext(typeof(StarwarsContext))]
    partial class StarwarsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("starwars_api_net_core.Models.Film", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Episode")
                        .HasColumnType("int");

                    b.Property<string>("OpeningCrawl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("starwars_api_net_core.Models.FilmPlanet", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlanetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "PlanetId");

                    b.HasIndex("PlanetId");

                    b.ToTable("FilmPlanet");
                });

            modelBuilder.Entity("starwars_api_net_core.Models.FilmSpecie", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpecieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "SpecieId");

                    b.HasIndex("SpecieId");

                    b.ToTable("FilmSpecie");
                });

            modelBuilder.Entity("starwars_api_net_core.Models.People", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BirthYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<Guid?>("HomeWorldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Mass")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkinColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SpecieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HomeWorldId");

                    b.HasIndex("SpecieId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("starwars_api_net_core.Models.PeopleFilms", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PeopleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "PeopleId");

                    b.HasIndex("PeopleId");

                    b.ToTable("PeopleFilms");
                });

            modelBuilder.Entity("starwars_api_net_core.Models.Planet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Climate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Diameter")
                        .HasColumnType("float");

                    b.Property<string>("Gravity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrbitalPeriod")
                        .HasColumnType("int");

                    b.Property<double>("Population")
                        .HasColumnType("float");

                    b.Property<int>("RotationPeriod")
                        .HasColumnType("int");

                    b.Property<int>("SurfaceWater")
                        .HasColumnType("int");

                    b.Property<string>("Terrain")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("starwars_api_net_core.Models.Specie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AverageHeight")
                        .HasColumnType("int");

                    b.Property<int>("AverageLifespan")
                        .HasColumnType("int");

                    b.Property<string>("Classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EyeColors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HairColors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HomeworldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkinColors")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeworldId");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("starwars_api_net_core.Models.FilmPlanet", b =>
                {
                    b.HasOne("starwars_api_net_core.Models.Film", "Film")
                        .WithMany("Planets")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("starwars_api_net_core.Models.Planet", "Planet")
                        .WithMany("Films")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("starwars_api_net_core.Models.FilmSpecie", b =>
                {
                    b.HasOne("starwars_api_net_core.Models.Film", "Film")
                        .WithMany("Species")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("starwars_api_net_core.Models.Specie", "Specie")
                        .WithMany("Films")
                        .HasForeignKey("SpecieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("starwars_api_net_core.Models.People", b =>
                {
                    b.HasOne("starwars_api_net_core.Models.Planet", "HomeWorld")
                        .WithMany("Residents")
                        .HasForeignKey("HomeWorldId");

                    b.HasOne("starwars_api_net_core.Models.Specie", "Specie")
                        .WithMany("People")
                        .HasForeignKey("SpecieId");
                });

            modelBuilder.Entity("starwars_api_net_core.Models.PeopleFilms", b =>
                {
                    b.HasOne("starwars_api_net_core.Models.Film", "Film")
                        .WithMany("Actors")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("starwars_api_net_core.Models.People", "People")
                        .WithMany("Films")
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("starwars_api_net_core.Models.Specie", b =>
                {
                    b.HasOne("starwars_api_net_core.Models.Planet", "Homeworld")
                        .WithMany()
                        .HasForeignKey("HomeworldId");
                });
#pragma warning restore 612, 618
        }
    }
}
