using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.ViewModel.Pokemon;
using Pokemon.Infrastructure;

namespace Pokemon.Core.Pokemon.Query
{
    public class GetAllHandler : IRequestHandler<AllPokemonsQuery, List<PokemonViewModel>>
    {
        public AppDbContext _context;
        public GetAllHandler(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<PokemonViewModel>> Handle(AllPokemonsQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.Pagination.page - 1) * request.Pagination.pageSize;
            return await _context.pokemons.OrderBy(x => x.id).Skip(skip).Take(request.Pagination.pageSize).Select(pokemon => new PokemonViewModel
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
                }).ToListAsync();
        }

    }
}
