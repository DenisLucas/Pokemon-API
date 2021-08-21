using System;
using System.Collections.Generic;
using MediatR;
using Pokemon.Core.Pokemon.Response.Query;
using Pokemon.Domain.ViewModel.Pokemon;

namespace Pokemon.Core.Pokemon.Query
{
    public class GetAllPokemonsQuery : IRequest<List<PokemonViewModel>>
    {
        public PaginationQuery Pagination {get; set;}
        public GetAllPokemonsQuery(PaginationQuery _pagination)
        {
            Pagination = _pagination;
        }
    }
}
