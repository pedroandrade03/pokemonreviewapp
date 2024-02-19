using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repositories;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ICollection<Category>))]
    public IActionResult GetCategories()
    {
        var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(categories);
    }
    
    [HttpGet("{categoryId:int}")]
    [ProducesResponseType(200, Type = typeof(Pokemon))]
    [ProducesResponseType(404)]
    public IActionResult GetCategory(int categoryId)
    {
        if (!_categoryRepository.CategoryExists(categoryId))
            return NotFound();
        
        var category = _mapper.Map<PokemonDto>(_categoryRepository.GetCategory(categoryId));
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(category);
    }
    
    [HttpGet("pokemon/{categoryId}")]
    [ProducesResponseType(200, Type = typeof(ICollection<Pokemon>))]
    [ProducesResponseType(404)]
    public IActionResult GetPokemonsByCategory(int categoryId)
    {
        if (!_categoryRepository.CategoryExists(categoryId))
            return NotFound();
        
        var pokemons = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonsByCategory(categoryId));
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(pokemons);
    }
}