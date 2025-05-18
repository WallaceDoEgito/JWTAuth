using System.Security.Claims;
using BarotraumaJWT.DTOs;
using BarotraumaJWT.Interfaces;
using BarotraumaJWT.Models;
using BarotraumaJWT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarotraumaJWT.Controllers;

[ApiController]
[Authorize]
[Route("api/characters")]
public class CharactersController(ICharacterService service):ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Characters>> CreateCharacter(UserRequestCharacterCreation request)
    {
        Characters? newCharacter =
            await service.CreateCharacter(request, (User.FindFirst(ClaimTypes.NameIdentifier)?.Value)!);
        
        if (newCharacter is null) return BadRequest("Nao foi possivel gerar esse personagem");
        return StatusCode(201 , newCharacter);

    }

    [HttpGet]
    public async Task<ActionResult<List<Characters>>> GetListCharacters()
    {
        List<Characters>? charList = await service.GetAllCharacters(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        if (charList == null) return BadRequest("Nao foi possivel concluir a operacao");
        return Ok(charList);
    }
}