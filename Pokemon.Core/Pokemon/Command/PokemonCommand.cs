using System;
using MediatR;
using Pokemon.Domain.Entities.Pokemon;
using Pokemon.Domain.ViewModel.Pokemon;

namespace Pokemon.Core.Pokemon.Command
{

    
    public class PokemonCommand : IRequest<Pokemons>
    {
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Spattack { get; set; }

        public int SpDefense { get; set; }
        public int Speed { get; set; }
        public int generation { get; set; }
        public bool legendary { get; set; }
    }
    public class PokemonEditCommand
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
        public int id;
        public PokemonEditCommand Pokemon;
        public PokemonEditWithIdCommand(int ID, PokemonEditCommand pokemon)
        {
            id = ID;
            Pokemon = pokemon;
        }
    }
    public class DeletePokemonCommand : IRequest<bool> 
    {

        public int Id;
        public DeletePokemonCommand(int ID)
        {
            Id = ID;
        }
    }
        
}
