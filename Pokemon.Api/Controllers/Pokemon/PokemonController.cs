using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Core.Helpers;
using Pokemon.Core.Pokemon.Command;
using Pokemon.Util.Helpers;
using Pokemon.Core.Pokemon.Query;
using Pokemon.Core.Pokemon.Response;
using Pokemon.Core.Pokemon.Response.Query;
using Pokemon.Domain.ViewModel.Pokemon;
using AutoMapper;

namespace Pokemon.Api.Controllers.Pokemon
{

    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        private readonly UrlHelper _urlHelpers;
        private const string Base = "/api/pokemon/";
        public PokemonController(IMediator mediator, UrlHelper urlHelpers, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
            _urlHelpers = urlHelpers;

        }

        [HttpGet(Base + "{id}/")]
        public async Task<IActionResult> getPokemonById(int id)
        {
            var query = new GetPokemonByIdQuery(id);
            var response = await _mediator.Send(query);
            if (response != null) return Ok(new Response<PokemonViewModel>(response));
            return BadRequest();
        }

        [HttpGet(Base)]
        public async Task<IActionResult> getAllPokemonsAsync([FromQuery]PaginationQuery paginationQuery)
        {
            
            var query = new GetAllPokemonsQuery(paginationQuery);
            var response = await _mediator.Send(query);
            if (paginationQuery == null || paginationQuery.page < 1 || paginationQuery.pageSize < 1)
            {
                return Ok(new PageResponse<PokemonViewModel>(response));
            }
            var pk = new PokemonPagination();
            var paginationResponse = pk.pagination(_urlHelpers,response,paginationQuery);
         
            if (response != null) return Ok(paginationResponse);
            return BadRequest();

        }
        [HttpGet(Base+"By/{gen}/")]
        public async Task<IActionResult> getPokemonsByGenerationAsync([FromQuery] PaginationQuery paginationQuery,int gen)
        {
            var query = new GetAllPokemonsByGenQuery(gen,paginationQuery);
            var response = await _mediator.Send(query);
            if (paginationQuery == null || paginationQuery.page < 1 || paginationQuery.pageSize < 1)
            {
                return Ok(new PageResponse<PokemonViewModel>(response));
            }
            var pk = new PokemonPagination();
            var paginationResponse = pk.pagination(_urlHelpers,response,paginationQuery);
         
            if (response != null) return Ok(paginationResponse);
            return BadRequest();
        }


        [HttpPost(Base)]
        public async Task<IActionResult> createPokemonAsync([FromBody] CreatePokemonCommand request)
        {
            var command = await _mediator.Send(request);
            var uri = _urlHelpers.GetUri(command.Id.ToString());

            if (command != null) return Created(uri, _mapper.Map<PokemonViewModel>(command));
            return BadRequest(); 
        }
        [HttpPut(Base+"{id}/")]
        public async Task<IActionResult> editPokemonAsync([FromBody] EditPokemonCommand request, int id)
        {
            var pokemon= new PokemonEditWithIdCommand(id,request);
            var command = await _mediator.Send(pokemon);
            var uri = _urlHelpers.GetUri(command.Id.ToString());

            if (command != null) return Ok();
            return BadRequest(); 
        }

        [HttpDelete(Base+"{id}/")]
        public async Task<IActionResult> deletePokemonAsync(int id)
        {
            var pokemon = new DeletePokemonCommand(id);
            var command = await _mediator.Send(pokemon);
            return Ok();
        }
    }
}
