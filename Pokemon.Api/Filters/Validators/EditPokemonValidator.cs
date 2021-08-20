using FluentValidation;
using Pokemon.Core.Pokemon.Command;

namespace Pokemon.Core.Filters.Validators
{
    public class EditPokemonValidators : AbstractValidator<PokemonEditCommand>
    {
        public EditPokemonValidators()
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
            RuleFor(x => x.Speed)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.SpAttack)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.SpDefense)
                .NotEmpty()
                .GreaterThan(0);
            

        }
    }
}
