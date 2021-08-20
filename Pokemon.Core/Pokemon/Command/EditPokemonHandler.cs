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
            
            var poke = await _context.pokemons.Where(x => x.id == request.id).FirstOrDefaultAsync(); 
            
            poke.name = request.Pokemon.Name;
            poke.type1 = request.Pokemon.Type1;
            poke.type2 = request.Pokemon.Type2;
            poke.total = request.Pokemon.Hp + request.Pokemon.Attack + request.Pokemon.Defense + request.Pokemon.Spattack + request.Pokemon.Speed;
            poke.hp = request.Pokemon.Hp;
            poke.attack = request.Pokemon.Attack;
            poke.defense = request.Pokemon.Defense;
            poke.spattack = request.Pokemon.Spattack;
            poke.speed = request.Pokemon.Speed;
            poke.generation = request.Pokemon.Generation;
            poke.legendary = Convert.ToByte(request.Pokemon.Legendary);
            await _context.SaveChangesAsync();

            return poke;
        }
    }
}
