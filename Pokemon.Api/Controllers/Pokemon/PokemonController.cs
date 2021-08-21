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

namespace Pokemon.Api.Controllers.Pokemon
{

    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly UrlHelper _urlHelpers;
        private const string Base = "/api/pokemon/";
        public PokemonController(IMediator mediator, UrlHelper urlHelpers)
        {
            _mediator = mediator;
            _urlHelpers = urlHelpers;

        }

        [HttpGet(Base + "{id}/")]
        public async Task<IActionResult> getPokemonById(int id)
        {
            var Query = new GetPokemonByIdQuery(id);
            var response = await _mediator.Send(Query);
            if (response != null) return Ok(new Response<PokemonViewModel>(response));
            return BadRequest();
        }

        [HttpGet(Base)]
        public async Task<IActionResult> getAllPokemonsAsync([FromQuery]PaginationQuery paginationQuery)
        {
            
            var Query = new GetAllPokemonsQuery(paginationQuery);
            var response = await _mediator.Send(Query);
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
            var Query = new GetAllPokemonsByGenQuery(gen,paginationQuery);
            var response = await _mediator.Send(Query);
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
            var Command = await _mediator.Send(request);
            var uri = _urlHelpers.GetUri(Command.Id.ToString());

            if (Command != null) return Created(uri,new PokemonViewModel 
            {
                Name = Command.Name,
                Type1 = Command.Type1,
                Type2 = Command.Type2,
                Total = Command.Total,
                Hp = Command.Hp,
                Attack = Command.Attack,
                Defense = Command.Defense,
                SpAttack = Command.SpAttack,
                SpDefense = Command.SpDefense,
                Speed = Command.Speed,
                Generation = Command.Generation,
                Legendary = Convert.ToBoolean(Command.Legendary)
            });
            return BadRequest(); 
        }
        [HttpPut(Base+"{id}/")]
        public async Task<IActionResult> editPokemonAsync([FromBody] EditPokemonCommand request, int id)
        {
            var pokemon= new PokemonEditWithIdCommand(id,request);
            var Command = await _mediator.Send(pokemon);
            var uri = _urlHelpers.GetUri(Command.Id.ToString());

            if (Command != null) return Ok();
            return BadRequest(); 
        }

        [HttpDelete(Base+"{id}/")]
        public async Task<IActionResult> deletePokemonAsync(int id)
        {
            var pokemon = new DeletePokemonCommand(id);
            var Command = await _mediator.Send(pokemon);
            return Ok();
        }
    }
}
