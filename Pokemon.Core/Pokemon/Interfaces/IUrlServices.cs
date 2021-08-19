using System;
using Pokemon.Core.Pokemon.Response.Query;

namespace Pokemon.Core.Pokemon.Interfaces
{
     public interface IUrlServices
    {
        Uri GetPokemonUri(string pokemonId);

        Uri GetAllPokemonsUri(PaginationQuery pagination = null);
    }
}
