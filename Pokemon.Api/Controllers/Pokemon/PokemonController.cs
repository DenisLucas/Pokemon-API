using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Core.Helpers;
using Pokemon.Core.Pokemon.Interfaces;
using Pokemon.Core.Pokemon.Query;
using Pokemon.Core.Pokemon.Response;
using Pokemon.Core.Pokemon.Response.Query;
using Pokemon.Domain.ViewModel.Pokemon;

namespace Pokemon.Api.Controllers.Pokemon
{

    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IUrlServices _urlServices;
        private const string Base = "/api/pokemon/";
        public PokemonController(IMediator mediator, IUrlServices urlServices)
        {
            _mediator = mediator;
            _urlServices = urlServices;

        }

        [HttpGet(Base + "{id}/")]
        public async Task<IActionResult> GetPokemonById(int id)
        {
            var Query = new PokemonQuery(id);
            var response = await _mediator.Send(Query);
            var locationuri = _urlServices.GetPokemonUri(id.ToString());
            if (response != null) return Ok(new Response<PokemonViewModel>(response));
            return BadRequest();
        }

        [HttpGet(Base)]
        public async Task<IActionResult> GetAllPokemons([FromQuery]PaginationQuery PaginationQuery)
        {

            var Query = new AllPokemonsQuery(PaginationQuery);
            var response = await _mediator.Send(Query);
            if (PaginationQuery == null || PaginationQuery.page < 1 || PaginationQuery.pageSize < 1)
            {
                return Ok(new PageResponse<PokemonViewModel>(response));
            }
            var paginationResponse = PaginationHelpers.CreatePaginationUri(_urlServices,PaginationQuery.page,PaginationQuery.pageSize,response);
            
            if (response != null) return Ok(paginationResponse);
            return BadRequest();

        }
        [HttpGet(Base+"getbyggen/{gen}/")]
        public async Task<IActionResult> GetPokemonsByGeneration([FromQuery] PaginationQuery PaginationQuery,int gen)
        {
            var Query = new PokemongenQuery(gen,PaginationQuery);
            var response = await _mediator.Send(Query);
            if (PaginationQuery == null || PaginationQuery.page < 1 || PaginationQuery.pageSize < 1)
            {
                return Ok(new PageResponse<PokemonViewModel>(response));
            }
            var paginationResponse = PaginationHelpers.CreatePaginationUri(_urlServices,PaginationQuery.page,PaginationQuery.pageSize,response);
            
            if (response != null) return Ok(paginationResponse);
            return BadRequest();
        }
    }
}
