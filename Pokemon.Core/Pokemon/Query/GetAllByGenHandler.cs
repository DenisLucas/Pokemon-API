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
    public class GetAllbyGenQuery : IRequestHandler<PokemongenQuery, List<PokemonViewModel>>
    {
        public AppDbContext _context;
        public GetAllbyGenQuery(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<PokemonViewModel>> Handle(PokemongenQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.pagination.page - 1) * request.pagination.pageSize;
            return await _context.pokemons.Where(x=> x.generation == request.Generation).OrderBy(x => x.id).Skip(skip).Take(request.pagination.pageSize).Select(pokemon => new PokemonViewModel
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
