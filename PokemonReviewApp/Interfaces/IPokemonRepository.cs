using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface IPokemonRepository
{
    ICollection<Pokemon> GetPokemon();
    Pokemon GetPokemon(int pokemonId);
    Pokemon GetPokemon(string pokemonName);
    decimal GetPokemonRating(int pokemonId);
    bool PokemonExists(int pokemonId);
}