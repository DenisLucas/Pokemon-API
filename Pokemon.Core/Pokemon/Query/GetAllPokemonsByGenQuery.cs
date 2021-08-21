using System;
using System.Collections.Generic;
using MediatR;
using Pokemon.Core.Pokemon.Response.Query;
using Pokemon.Domain.ViewModel.Pokemon;

namespace Pokemon.Core.Pokemon.Query
{
    public class GetAllPokemonsByGenQuery : IRequest<List<PokemonViewModel>>
    {
        public int Generation { get; set; }
        public PaginationQuery Pagination {get; set;}
        
        public GetAllPokemonsByGenQuery(int _generation, PaginationQuery _pagination)
        {
            Generation = _generation;
            Pagination = _pagination;
        
        }
    }
}
