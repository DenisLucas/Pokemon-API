using System;
using System.Collections.Generic;
using System.Linq;
using Pokemon.Core.Pokemon.Interfaces;
using Pokemon.Core.Pokemon.Response;
using Pokemon.Core.Pokemon.Response.Query;
using Pokemon.Domain.ViewModel.Pokemon;

namespace Pokemon.Core.Helpers
{
    public class PaginationHelpers
    {
        public static object CreatePaginationUri(IUrlServices _urlServices, int page,int pageSize, List<PokemonViewModel> response)
        {
            var nextPage = page >= 1 ? _urlServices.GetAllPokemonsUri(new PaginationQuery(page + 1,  pageSize)).ToString() : null;
            var lastPage = page >= 1 ? _urlServices.GetAllPokemonsUri(new PaginationQuery(page - 1,  pageSize)).ToString() : null;
            
            var paginationResponse = new PageResponse<PokemonViewModel>
            {
                Data = response,
                Page = page >= 1 ? page : (int?)null,
                PageSize = pageSize >= 1 ? pageSize : (int?)null,
                NextPage = response.Any() ?  nextPage : null,
                LastPage = lastPage 
            };
            return paginationResponse;
        }
    }
}
