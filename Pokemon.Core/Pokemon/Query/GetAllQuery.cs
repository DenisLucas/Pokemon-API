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
    public class GetAllQuery : IRequestHandler<AllPokemonsQuery, List<PokemonViewModel>>
    {
        public AppDbContext _context;
        public GetAllQuery(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<PokemonViewModel>> Handle(AllPokemonsQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.pagination.page - 1) * request.pagination.pageSize;
            return await _context.pokemons.OrderBy(x => x.id).Skip(skip).Take(request.pagination.pageSize).Select(pokemon => new PokemonViewModel
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
                }).ToListAsync();
        }

    }
}
