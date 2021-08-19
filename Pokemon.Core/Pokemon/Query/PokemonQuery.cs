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
}
