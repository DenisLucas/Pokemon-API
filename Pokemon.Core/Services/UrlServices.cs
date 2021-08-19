using System;
using Microsoft.AspNetCore.WebUtilities;
using Pokemon.Core.Pokemon.Interfaces;
using Pokemon.Core.Pokemon.Response.Query;

namespace Pokemon.Core.Pokemon.Services
{
    public class UrlServices : IUrlServices
    {
        private readonly string _baseUrl;
        public UrlServices(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public Uri GetAllPokemonsUri(PaginationQuery pagination = null)
        {
            var _uri = new Uri(_baseUrl);
            if (pagination == null) return _uri;

            var modifieduri = QueryHelpers.AddQueryString(_baseUrl, "page", pagination.page.ToString());
            modifieduri = QueryHelpers.AddQueryString(modifieduri, "pageSize", pagination.pageSize.ToString());
            return new Uri(modifieduri);
        }

        public Uri GetPokemonUri(string pokemonId)
        {
            return new Uri(_baseUrl + "/get/api/v1/{id}".Replace("{id}", pokemonId));
        }
    }
}
