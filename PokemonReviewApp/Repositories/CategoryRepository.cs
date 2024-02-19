using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _dataContext;

    public CategoryRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public ICollection<Category> GetCategories()
    {
        return _dataContext.Categories.ToList();
    }

    public Category GetCategory(int categoryId)
    {
        return _dataContext.Categories.FirstOrDefault(c => c.Id == categoryId);
    }

    public ICollection<Pokemon> GetPokemonsByCategory(int categoryId)
    {
        return _dataContext.PokemonCategories
            .Where(pc => pc.CategoryId == categoryId)
            .Select(pc => pc.Pokemon)
            .ToList();
    }

    public bool CategoryExists(int categoryId)
    {
        return _dataContext.Categories.Any(c => c.Id == categoryId);
    }
}