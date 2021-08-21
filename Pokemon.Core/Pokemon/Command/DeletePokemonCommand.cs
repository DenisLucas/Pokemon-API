using System;
using MediatR;

namespace Pokemon.Core.Pokemon.Command
{
    public class DeletePokemonCommand : IRequest<bool> 
    {
        public int Id {get; set;}
        public DeletePokemonCommand(int ID)
        {
            Id = ID;
        }
    }
}
