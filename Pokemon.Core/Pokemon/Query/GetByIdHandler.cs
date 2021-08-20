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
    public class GetByIdHandler : IRequestHandler<PokemonQuery, PokemonViewModel>
    {
        public AppDbContext _context;
        public GetByIdHandler(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<PokemonViewModel> Handle(PokemonQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.pokemons.Where(x => x.id == request.Id)
                .Select(pokemon => new PokemonViewModel
                {
                   Name = pokemon.name,
                   Type1 = pokemon.type1,
                   Type2 = pokemon.type2,
                   Total = pokemon.total,
                   Hp = pokemon.hp,
                   Attack = pokemon.attack,
                   Defense = pokemon.defense,
                   Spattack = pokemon.spattack,
                   Speed = pokemon.speed,
                   Generation = pokemon.generation,
                   legendary = Convert.ToBoolean(pokemon.legendary) 
                }).FirstOrDefaultAsync();
            return response;
        }
    }
}
