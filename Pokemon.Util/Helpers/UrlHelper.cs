using System;
using Microsoft.AspNetCore.WebUtilities;
using Pokemon.Core.Pokemon.Response.Query;

namespace Pokemon.Util.Helpers
{
    public class UrlHelper
    {
        private readonly string _baseUrl;
        public UrlHelper(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public Uri GetAllUri(PaginationQuery pagination = null)
        {
            var _uri = new Uri(_baseUrl);
            if (pagination == null) return _uri;

            var modifieduri = QueryHelpers.AddQueryString(_baseUrl, "page", pagination.page.ToString());
            modifieduri = QueryHelpers.AddQueryString(modifieduri, "pageSize", pagination.pageSize.ToString());
            return new Uri(modifieduri);
        }

        public Uri GetUri(string pokemonId)
        {
            return new Uri(_baseUrl + "/get/api/v1/{id}".Replace("{id}", pokemonId));
        }
    }
}
