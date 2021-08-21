using System;
using System.Threading.Tasks;
using FakeItEasy;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pokemon.Core.Pokemon.Command;
using Pokemon.Core.Pokemon.Query;
using Pokemon.Core.Pokemon.Response.Query;
using Pokemon.Domain.Entities.Pokemon;
using Pokemon.Infrastructure;
using Xunit;

namespace Pokemon.Tests.Pokemon
{
    public class PokemonHandlersTest
    {
        [Fact]
        public async Task createPokemonHandleReturnPokemons()
        {
            var _mediator = A.Fake<IMediator>();
            var pokemon = new CreatePokemonCommand
            {

            };
        
            var action = await _mediator.Send(pokemon);
            Assert.NotNull(action);
            Assert.Equal("Castle.Proxies.PokemonsProxy", action.GetType().ToString());



        }
    
        [Fact]
        public async Task editPokemonHandleReturnPokemons()
        {
            var _mediator = A.Fake<IMediator>();
            var pokemon = new EditPokemonCommand
            {

            };
        
            var action = await _mediator.Send(pokemon);
            Assert.NotNull(action);

            Assert.Equal("Castle.Proxies.ObjectProxy_2", action.GetType().ToString());

        }
        [Fact]
        public async Task deletePokemonHandleReturnFalse()
        {
            var _mediator = A.Fake<IMediator>();
            
            var pokemon = new DeletePokemonCommand(1);
            

            var action = await _mediator.Send(pokemon);
            Assert.False(action);
        }
        [Fact]
        public async Task getPokemonByIdReturnsPokemonViewModel()
        {
            var _mediator = A.Fake<IMediator>();
            
            var pokemon = new GetPokemonByIdQuery(1);
            var action = await _mediator.Send(pokemon);
            
            Assert.NotNull(action);
            Assert.Equal("Castle.Proxies.PokemonViewModelProxy", action.GetType().ToString());

            
        }

        [Fact]
        public async Task getAllPokemonsReturnsListPageResponse()
        {
            var _mediator = A.Fake<IMediator>();
            var _pagination = A.Fake<PaginationQuery>();
            var pokemon = new GetAllPokemonsQuery(_pagination);
            var action = await _mediator.Send(pokemon);
            
            Assert.NotNull(action);
            Assert.Equal("Castle.Proxies.List`1Proxy", action.GetType().ToString());

            
        }

        [Fact]
        public async Task getAllPokemonByGenReturnsListPokemonViewModel()
        {
            
            var _mediator = A.Fake<IMediator>();
            var _pagination = A.Fake<PaginationQuery>();
            var pokemon = new GetAllPokemonsByGenQuery(1,_pagination);
            var action = await _mediator.Send(pokemon);
            
            Assert.NotNull(action);
            Assert.Equal("Castle.Proxies.List`1Proxy", action.GetType().ToString());

            
            
        }
    }

}
