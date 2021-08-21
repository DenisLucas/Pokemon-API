using System;
using MediatR;
using Pokemon.Domain.Entities.Pokemon;

namespace Pokemon.Core.Pokemon.Command
{
    public class EditPokemonCommand
    {
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }
        public bool Legendary { get; set; }
    }
    public class PokemonEditWithIdCommand : IRequest<Pokemons>
    {
        public int Id {get; set;}
        public EditPokemonCommand Pokemon {get; set;}
        public PokemonEditWithIdCommand(int ID, EditPokemonCommand pokemon)
        {
            Id = ID;
            Pokemon = pokemon;
        }
    }
    
}
