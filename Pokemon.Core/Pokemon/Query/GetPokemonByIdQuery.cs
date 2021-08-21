using System;
using System.Collections.Generic;
using MediatR;
using Pokemon.Core.Pokemon.Response.Query;
using Pokemon.Domain.ViewModel.Pokemon;

namespace Pokemon.Core.Pokemon.Query
{
    public class GetPokemonByIdQuery : IRequest<PokemonViewModel>
    {
        public int Id {get; set;}
        public GetPokemonByIdQuery(int _id)
        {
            Id = _id;
        }
    }
        
}
