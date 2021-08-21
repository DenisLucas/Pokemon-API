using System;
using AutoMapper;
using Pokemon.Domain.Entities.Pokemon;
using Pokemon.Domain.ViewModel.Pokemon;

namespace Pokemon.Core.Mapping.Pokemon
{
    public class MappingPokemonToPokemonViewModel : Profile
    {
        public MappingPokemonToPokemonViewModel()
        {
               CreateMap<Pokemons, PokemonViewModel>();   
        }
    }
}
