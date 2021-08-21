using System;
using System.Collections.Generic;
using System.Linq;
using Pokemon.Util.Helpers;
using Pokemon.Core.Pokemon.Response;
using Pokemon.Core.Pokemon.Response.Query;
using Pokemon.Domain.ViewModel.Pokemon;

namespace Pokemon.Core.Helpers
{
    public class Pagination<T>
    {
        public PageResponse<T> createPaginationUri(PaginationQuery pageQ, IEnumerable<T> response, string nextPage, string lastPage)
        {

            
            var paginationResponse = new PageResponse<T>
            {
                Data = response,
                Page = pageQ.page >= 1 ? pageQ.page : (int?)null,
                PageSize = pageQ.pageSize >= 1 ? pageQ.pageSize : (int?)null,
                NextPage = response.Any() ?  nextPage : null,
                LastPage = lastPage 
            };
            return paginationResponse;
        }
    }

    public  class PokemonPagination : Pagination<PokemonViewModel>
    {
        public PageResponse<PokemonViewModel> pagination(UrlHelper urlHelper, IEnumerable<PokemonViewModel> pokemons, PaginationQuery pageQ)
        {
            var nextPage = pageQ.page >= 1 ? urlHelper.GetAllUri(new PaginationQuery(pageQ.page + 1,  pageQ.pageSize)).ToString() : null;
            var lastPage = pageQ.page >= 1 ? urlHelper.GetAllUri(new PaginationQuery(pageQ.page - 1,  pageQ.pageSize)).ToString() : null;
            return createPaginationUri(pageQ,pokemons,nextPage,lastPage);

        }
    }
}
