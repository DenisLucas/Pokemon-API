using System;
using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.Entities.Pokemon;

namespace Pokemon.Infrastructure
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options): base(options)
        {

        }
        public DbSet<Pokemons> Pokemons { get; set; }
    }
}

