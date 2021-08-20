using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Core.Helpers;
using Pokemon.Core.Pokemon.Command;
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
        public async Task<IActionResult> GetAllPokemonsAsync([FromQuery]PaginationQuery paginationQuery)
        {
            
            var Query = new AllPokemonsQuery(paginationQuery);
            var response = await _mediator.Send(Query);
            if (paginationQuery == null || paginationQuery.page < 1 || paginationQuery.pageSize < 1)
            {
                return Ok(new PageResponse<PokemonViewModel>(response));
            }
            var paginationResponse = PaginationHelpers.CreatePaginationUri(_urlServices,paginationQuery.page,paginationQuery.pageSize,response);
            
            if (response != null) return Ok(paginationResponse);
            return BadRequest();

        }
        [HttpGet(Base+"By/{gen}/")]
        public async Task<IActionResult> GetPokemonsByGenerationAsync([FromQuery] PaginationQuery paginationQuery,int gen)
        {
            var Query = new PokemongenQuery(gen,paginationQuery);
            var response = await _mediator.Send(Query);
            if (paginationQuery == null || paginationQuery.page < 1 || paginationQuery.pageSize < 1)
            {
                return Ok(new PageResponse<PokemonViewModel>(response));
            }
            var paginationResponse = PaginationHelpers.CreatePaginationUri(_urlServices,paginationQuery.page,paginationQuery.pageSize,response);
            
            if (response != null) return Ok(paginationResponse);
            return BadRequest();
        }


        [HttpPost(Base)]
        public async Task<IActionResult> CreatePokemonAsync([FromBody] PokemonCommand request)
        {
            var Command = await _mediator.Send(request);
            var uri = _urlServices.GetPokemonUri(Command.Id.ToString());

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
                legendary = Convert.ToBoolean(Command.Legendary)
            });
            return BadRequest(); 
        }
        [HttpPut(Base+"{id}/")]
        public async Task<IActionResult> EditPokemonAsync([FromBody] PokemonEditCommand request, int id)
        {
            var pokemon= new PokemonEditWithIdCommand(id,request);
            var Command = await _mediator.Send(pokemon);
            var uri = _urlServices.GetPokemonUri(Command.Id.ToString());

            if (Command != null) return Ok();
            return BadRequest(); 
        }

        [HttpDelete(Base+"{id}/")]
        public async Task<IActionResult> DeletePokemonAsync(int id)
        {
            var pokemon = new DeletePokemonCommand(id);
            var Command = await _mediator.Send(pokemon);
            if (Command) return Ok();
            return BadRequest();
        }
    }
}
