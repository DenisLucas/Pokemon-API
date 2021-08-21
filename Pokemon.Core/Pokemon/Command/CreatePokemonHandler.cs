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
                Name = request.Name,
                Type1 = request.Type1,
                Type2 = request.Type2,
                Total = request.Hp + request.Attack + request.Defense + request.Spattack + request.Speed,
                Hp = request.Hp,
                Attack = request.Attack,
                Defense = request.Defense,
                SpAttack = request.Spattack,
                SpDefense = request.SpDefense,
                Speed = request.Speed,
                Generation = request.generation,
                Legendary = Convert.ToByte(request.Legendary)
            };
            await _context.pokemons.AddAsync(poke);
            await _context.SaveChangesAsync();

            return poke;
        }
    }
}
