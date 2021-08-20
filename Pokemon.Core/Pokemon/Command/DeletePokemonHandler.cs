using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pokemon.Infrastructure;

namespace Pokemon.Core.Pokemon.Command
{
    public class DeletePokemonHandler : IRequestHandler<DeletePokemonCommand, bool>
    {

        public AppDbContext _context;
        public DeletePokemonHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeletePokemonCommand request, CancellationToken cancellationToken)
        {
            var removed = await _context.pokemons.Where(x => x.id == request.Id).FirstOrDefaultAsync();       
            _context.pokemons.Remove(removed);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }
    }
}
