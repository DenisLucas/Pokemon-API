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
    public class GetAllPokemonsbyGenQuery : IRequestHandler<GetAllPokemonsByGenQuery, List<PokemonViewModel>>
    {
        public PokemonDbContext _context;
        public GetAllPokemonsbyGenQuery(PokemonDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<PokemonViewModel>> Handle(GetAllPokemonsByGenQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.Pagination.page - 1) * request.Pagination.pageSize;
            return await _context.Pokemons.Where(x=> x.Generation == request.Generation).OrderBy(x => x.Id).Skip(skip).Take(request.Pagination.pageSize).Select(pokemon => new PokemonViewModel
                {
                    Name = pokemon.Name,
                    Type1 = pokemon.Type1,
                    Type2 = pokemon.Type2,
                    Total = pokemon.Total,
                    Hp = pokemon.Hp,
                    Attack = pokemon.Attack,
                    Defense = pokemon.Defense,
                    SpAttack = pokemon.SpAttack,

                    SpDefense = pokemon.SpDefense,
                    Speed = pokemon.Speed,
                    Generation = pokemon.Generation,
                    Legendary = Convert.ToBoolean(pokemon.Legendary) 
                }).ToListAsync();
        }

    }
}
