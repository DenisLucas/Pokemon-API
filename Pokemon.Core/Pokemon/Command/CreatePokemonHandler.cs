using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pokemon.Domain.Entities.Pokemon;
using Pokemon.Infrastructure;

namespace Pokemon.Core.Pokemon.Command
{
    public class CreatePokemonHandler : IRequestHandler<PokemonCommand, Pokemons>
    {
        public AppDbContext _context;
        public CreatePokemonHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Pokemons> Handle(PokemonCommand request, CancellationToken cancellationToken)
        {
            var poke = new Pokemons 
            {
                name = request.name,
                type1 = request.type1,
                type2 = request.type2,
                total = request.hp + request.attack + request.defense + request.spattack + request.speed,
                hp = request.hp,
                attack = request.attack,
                defense = request.defense,
                spattack = request.spattack,
                speed = request.speed,
                generation = request.generation,
                legendary = Convert.ToByte(request.legendary)
            };
            await _context.pokemons.AddAsync(poke);
            await _context.SaveChangesAsync();

            return poke;
        }
    }
}
