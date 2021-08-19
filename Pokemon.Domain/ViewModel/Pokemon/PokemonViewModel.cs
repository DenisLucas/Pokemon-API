using System;

namespace Pokemon.Domain.ViewModel.Pokemon
{
    public class PokemonViewModel
    {

        public string name { get; set; }
        public string type1 { get; set; }
        public string type2 { get; set; }
        public int total { get; set; }
        public int hp { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int spattack { get; set; }
        public int speed { get; set; }
        public int generation { get; set; }
        public bool legendary { get; set; }
    }
}
