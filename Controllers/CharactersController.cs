using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarotraumaJWT.Controllers;

[ApiController]
[Authorize]
[Route("api/characters")]
public class CharactersController:ControllerBase
{
    [HttpPost]
    public IActionResult CreateCharacter()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetListCharacters()
    {
        return Ok();
    }
}