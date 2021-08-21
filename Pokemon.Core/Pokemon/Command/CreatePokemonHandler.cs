using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pokemon.Domain.Entities.Pokemon;
using Pokemon.Infrastructure;

namespace Pokemon.Core.Pokemon.Command
{
    public class CreatePokemonHandler : IRequestHandler<CreatePokemonCommand, Pokemons>
    {
        public PokemonDbContext _context;
        public CreatePokemonHandler(PokemonDbContext context)
        {
            _context = context;
        }
        public async Task<Pokemons> Handle(CreatePokemonCommand request, CancellationToken cancellationToken)
        {
            var poke = new Pokemons 
            {
                Name = request.Name,
                Type1 = request.Type1,
                Type2 = request.Type2,
                Total = request.Hp + request.Attack + request.Defense + request.SpAttack + request.Speed,
                Hp = request.Hp,
                Attack = request.Attack,
                Defense = request.Defense,
                SpAttack = request.SpAttack,
                SpDefense = request.SpDefense,
                Speed = request.Speed,
                Generation = request.Generation,
                Legendary = Convert.ToByte(request.Legendary)
            };
            await _context.Pokemons.AddAsync(poke);
            await _context.SaveChangesAsync();

            return poke;
        }
    }
}
