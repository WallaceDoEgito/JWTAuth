using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarotraumaJWT.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CharactersController:ControllerBase
{
    
}