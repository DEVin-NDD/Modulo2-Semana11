using Microsoft.AspNetCore.Mvc;

namespace ProjetoSemana11.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
