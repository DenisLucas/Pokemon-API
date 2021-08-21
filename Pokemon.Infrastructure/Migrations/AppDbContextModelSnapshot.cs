﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokemon.Infrastructure;

namespace Pokemon.Infrastructure.Migrations
{
    [DbContext(typeof(PokemonDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pokemon.Domain.Entities.Pokemon.Pokemons", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("attack")
                        .HasColumnType("int");

                    b.Property<int>("defense")
                        .HasColumnType("int");

                    b.Property<int>("generation")
                        .HasColumnType("int");

                    b.Property<int>("hp")
                        .HasColumnType("int");

                    b.Property<bool>("legendary")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("spattack")
                        .HasColumnType("int");

                    b.Property<int>("speed")
                        .HasColumnType("int");

                    b.Property<int>("total")
                        .HasColumnType("int");

                    b.Property<string>("type1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("pokemons");
                });
#pragma warning restore 612, 618
        }
    }
}
