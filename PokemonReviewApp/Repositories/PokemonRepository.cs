using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private readonly DataContext _dataContext;

    public PokemonRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public ICollection<Pokemon> GetPokemon()
    {
        return _dataContext.Pokemon.OrderBy(p => p.Id).ToList();
    }

    public Pokemon GetPokemon(int pokemonId)
    {
        return _dataContext.Pokemon.FirstOrDefault(p => p.Id == pokemonId);
    }

    public Pokemon GetPokemon(string pokemonName)
    {
        return _dataContext.Pokemon.FirstOrDefault(p => p.Name == pokemonName);
    }
    
    
    public decimal GetPokemonRating(int pokemonId)
    {
        var averageRating = _dataContext.Reviews
            .Where(r => r.Pokemon.Id == pokemonId)
            .Average(r => (decimal?)r.Rating);
        
        return averageRating ?? 0;
    }

    public bool PokemonExists(int pokemonId)
    {
        return  _dataContext.Pokemon.Any(p => p.Id == pokemonId);
    }
}