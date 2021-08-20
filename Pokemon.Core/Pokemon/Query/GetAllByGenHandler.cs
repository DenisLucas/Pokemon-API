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
            return await _context.pokemons.Where(x=> x.Generation == request.Generation).OrderBy(x => x.Id).Skip(skip).Take(request.pagination.pageSize).Select(pokemon => new PokemonViewModel
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
                    legendary = Convert.ToBoolean(pokemon.Legendary) 
                }).ToListAsync();
        }

    }
}
