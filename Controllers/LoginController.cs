using Microsoft.AspNetCore.Mvc;

namespace BarotraumaJWT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpGet]
    public IActionResult TomaToma()
    {
        return Ok();
    }
    
}