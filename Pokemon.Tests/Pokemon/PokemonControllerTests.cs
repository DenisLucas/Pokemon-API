
using System;
using System.Threading.Tasks;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Api.Controllers.Pokemon;
using Pokemon.Core.Pokemon.Command;
using Pokemon.Util.Helpers;
using Xunit;
namespace Pokemon.Tests.Pokemon
{
    public class PokemonControllerTests
    {
        [Fact]
        public async Task CreatePokemonAsyncShouldReturnPokemonModelView()
        {
        //Given
        var _mediator = A.Fake<IMediator>();
        var _urlServices = A.Fake<UrlHelper>();
        PokemonController pokemonController = new PokemonController(_mediator,_urlServices);
        var pokemon = new CreatePokemonCommand
            {
                Name = "Pokemon",
                Type1 = "fogo",
                Type2 = "",
                Hp = 100,
                Attack = 50,
                Defense = 10,
                Spattack = 20,
                SpDefense = 10,
                Speed = 6,
                generation = 3,
                Legendary = false

            };
        //When
        IActionResult result = await pokemonController.createPokemonAsync(pokemon);
        var okResult = result as CreatedResult;

        // assert

        Assert.NotNull(okResult);
        Console.Write(okResult);
        Assert.Equal(201, okResult.StatusCode);
        //Then
        Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public async Task EditPokemonAsyncShouldReturnPokemonModelView()
        {
        //Given
        var _mediator = A.Fake<IMediator>();
        var _urlServices = A.Fake<UrlHelper>();
        PokemonController pokemonController = new PokemonController(_mediator,_urlServices);
        var pokemon = new EditPokemonCommand
            {
                Name = "Pokemon",
                Type1 = "fogo",
                Type2 = "",
                Hp = 100,
                Attack = 50,
                Defense = 10,
                SpAttack = 20,
                SpDefense = 10,
                Speed = 6,
                Generation = 3,
                Legendary = false

            };
        //When
        IActionResult result = await pokemonController.editPokemonAsync(pokemon, 69);
        var okResult = result as OkResult;

        // assert

        Assert.Equal(200, okResult.StatusCode);
        }
 
    }
}
