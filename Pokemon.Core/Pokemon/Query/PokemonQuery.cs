using System;
using System.Collections.Generic;
using MediatR;
using Pokemon.Core.Pokemon.Response.Query;
using Pokemon.Domain.ViewModel.Pokemon;

namespace Pokemon.Core.Pokemon.Query
{
    public class PokemonQuery : IRequest<PokemonViewModel>
    {
        public int id;
        public PokemonQuery(int _id)
        {
            id = _id;
        }
    }
    public class AllPokemonsQuery : IRequest<List<PokemonViewModel>>
    {
        public PaginationQuery pagination;
        public AllPokemonsQuery(PaginationQuery _pagination)
        {
            pagination = _pagination;
        }
    }
    public class PokemongenQuery : IRequest<List<PokemonViewModel>>
    {
        public int generation;
        public PaginationQuery pagination;
        
        public PokemongenQuery(int _generation, PaginationQuery _pagination)
        {
            generation = _generation;
            pagination = _pagination;
        
        }
    }
        
}
