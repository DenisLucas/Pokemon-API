using System;
using FluentValidation;
using Pokemon.Core.Pokemon.Command;

namespace Pokemon.Core.Filters.Validators
{
    public class CreatePokemonValidators : AbstractValidator<PokemonCommand>
    {
        public CreatePokemonValidators()
        {
            RuleFor(x => x.Hp)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.Attack)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.Defense)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.Spattack)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.Speed)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.Spattack)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.SpDefense)
                .NotEmpty()
                .GreaterThan(0);
            

        }
    }
}
