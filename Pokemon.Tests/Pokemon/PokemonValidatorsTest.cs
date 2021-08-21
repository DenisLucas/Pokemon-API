using Xunit;
using Pokemon.Core.Pokemon.Command;
using FluentValidation.TestHelper;
using Pokemon.Core.Filters.Validators;


namespace Pokemon.Tests.Pokemon
{
    public class PokemonValidatorsTest
    {
        
        [Fact]
        public void CreatePokemonValidatorTestShouldReturnError()
        {
            var pokemon = new CreatePokemonCommand
                {

                };
            
            var Validator = new CreatePokemonValidators();
            
            // Test IActionResult return

            // Test Validator
            var result = Validator.TestValidate(pokemon);
            result.ShouldHaveValidationErrorFor(s=> s.Attack);
            result.ShouldHaveValidationErrorFor(s=> s.Defense);
            result.ShouldHaveValidationErrorFor(s=> s.Spattack);
            result.ShouldHaveValidationErrorFor(s=> s.SpDefense);
            result.ShouldHaveValidationErrorFor(s=> s.Speed);
            result.ShouldHaveValidationErrorFor(s=> s.Hp);
            
        }
        [Fact]
        public void EditPokemonValidatorTestShouldReturnError()
        {
            var pokemon = new EditPokemonCommand
                {

                };
            
            var Validator = new EditPokemonValidators();
            
            // Test IActionResult return

            // Test Validator
            var result = Validator.TestValidate(pokemon);
            result.ShouldHaveValidationErrorFor(s=> s.Attack);
            result.ShouldHaveValidationErrorFor(s=> s.Defense);
            result.ShouldHaveValidationErrorFor(s=> s.SpAttack);
            result.ShouldHaveValidationErrorFor(s=> s.SpDefense);
            result.ShouldHaveValidationErrorFor(s=> s.Speed);
            result.ShouldHaveValidationErrorFor(s=> s.Hp);
            
        }




            
    }
}
