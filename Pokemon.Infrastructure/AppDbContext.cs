using System;
using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.Entities.Pokemon;

namespace Pokemon.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Pokemons> pokemons { get; set; }
    }
}

