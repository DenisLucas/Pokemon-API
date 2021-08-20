using System;
using System.Collections.Generic;
using MediatR;
using Pokemon.Core.Pokemon.Response.Query;
using Pokemon.Domain.ViewModel.Pokemon;

namespace Pokemon.Core.Pokemon.Query
{
    public class PokemonQuery : IRequest<PokemonViewModel>
    {
        public int Id;
        public PokemonQuery(int _id)
        {
            Id = _id;
        }
    }
    public class AllPokemonsQuery : IRequest<List<PokemonViewModel>>
    {
        public PaginationQuery Pagination;
        public AllPokemonsQuery(PaginationQuery _pagination)
        {
            Pagination = _pagination;
        }
    }
    public class PokemongenQuery : IRequest<List<PokemonViewModel>>
    {
        public int Generation;
        public PaginationQuery pagination;
        
        public PokemongenQuery(int _generation, PaginationQuery _pagination)
        {
            Generation = _generation;
            pagination = _pagination;
        
        }
    }
        
}
