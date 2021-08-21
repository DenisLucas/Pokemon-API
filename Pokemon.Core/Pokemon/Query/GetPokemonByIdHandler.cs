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
    public class GetPokemonByIdHandler : IRequestHandler<GetPokemonByIdQuery, PokemonViewModel>
    {
        public PokemonDbContext _context;
        public GetPokemonByIdHandler(PokemonDbContext context)
        {
            _context = context;
        }
        
        public async Task<PokemonViewModel> Handle(GetPokemonByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Pokemons.Where(x => x.Id == request.Id)
                .Select(pokemon => new PokemonViewModel
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
                }).FirstOrDefaultAsync();
            return response;
        }
    }
}
