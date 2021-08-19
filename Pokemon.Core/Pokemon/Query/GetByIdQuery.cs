using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.ViewModel.Pokemon;
using Pokemon.Infrastructure;

namespace Pokemon.Core.Pokemon.Query
{
    public class GetByIdQuery : IRequestHandler<PokemonQuery, PokemonViewModel>
    {
        public AppDbContext _context;
        public GetByIdQuery(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<PokemonViewModel> Handle(PokemonQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.pokemons.Where(x => x.id == request.id)
                .Select(pokemon => new PokemonViewModel
                {
                   name = pokemon.name,
                   type1 = pokemon.type1,
                   type2 = pokemon.type2,
                   total = pokemon.total,
                   hp = pokemon.hp,
                   attack = pokemon.attack,
                   defense = pokemon.defense,
                   spattack = pokemon.spattack,
                   speed = pokemon.speed,
                   generation = pokemon.generation,
                   legendary = Convert.ToBoolean(pokemon.legendary) 
                }).FirstOrDefaultAsync();
            return response;
        }
    }
}
