using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.Entities.Pokemon;
using Pokemon.Infrastructure;

namespace Pokemon.Core.Pokemon.Command
{
    public class EditPokemonHandler : IRequestHandler<PokemonEditWithIdCommand, Pokemons>
    {
        public AppDbContext _context;
        public EditPokemonHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Pokemons> Handle(PokemonEditWithIdCommand request, CancellationToken cancellationToken)
        {
            
            var poke = await _context.pokemons.Where(x => x.Id == request.id).FirstOrDefaultAsync(); 
            
            poke.Name = request.Pokemon.Name;
            poke.Type1 = request.Pokemon.Type1;
            poke.Type2 = request.Pokemon.Type2;
            poke.Total = request.Pokemon.Hp + request.Pokemon.Attack + request.Pokemon.Defense + request.Pokemon.SpAttack + request.Pokemon.Speed;
            poke.Hp = request.Pokemon.Hp;
            poke.Attack = request.Pokemon.Attack;
            poke.Defense = request.Pokemon.Defense;
            poke.SpAttack = request.Pokemon.SpAttack;
            poke.SpDefense = request.Pokemon.SpDefense;
            poke.Speed = request.Pokemon.Speed;
            poke.Generation = request.Pokemon.Generation;
            poke.Legendary = Convert.ToByte(request.Pokemon.Legendary);
            await _context.SaveChangesAsync();

            return poke;
        }
    }
}
