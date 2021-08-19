using System;

namespace Pokemon.Domain.Entities.Pokemon
{
    public class pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type1 { get; set; }
        public string type2 { get; set; }
        public int hp { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int spattack { get; set; }
        public int spattack { get; set; }
        public int speed { get; set; }
        public int generation { get; set; }
        public bool legendary { get; set; }
    
    }   
}
