using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : Controller
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IMapper _mapper;

    public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
    {
        _mapper = mapper;
        _pokemonRepository = pokemonRepository;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ICollection<Pokemon>))]
    public IActionResult GetPokemon()
    {
        var pokemon = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemon());
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(pokemon);
    }
    
    [HttpGet("{pokemonId:int}")]
    [ProducesResponseType(200, Type = typeof(Pokemon))]
    [ProducesResponseType(404)]
    public IActionResult GetPokemon(int pokemonId)
    {
        if (!_pokemonRepository.PokemonExists(pokemonId))
            return NotFound();
        
        var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokemonId));
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(pokemon);
    }
    
    [HttpGet("{pokemonId}/rating")]
    [ProducesResponseType(200, Type = typeof(decimal))]
    [ProducesResponseType(404)]
    public IActionResult GetPokemonRating(int pokemonId)
    {
        if (!_pokemonRepository.PokemonExists(pokemonId))
            return NotFound();
        
        var rating = _pokemonRepository.GetPokemonRating(pokemonId);
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(rating);
    }
}