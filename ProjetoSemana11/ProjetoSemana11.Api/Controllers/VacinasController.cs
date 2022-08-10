using Microsoft.AspNetCore.Mvc;
using ProjetoSemana11.Data;
using ProjetoSemana11.Models;

namespace ProjetoSemana11.Api.Controllers;

[ApiController]
[Route("api/vacinas")]
public class VacinasController : ControllerBase
{
    private readonly ProjetoDbContext _context;

    public VacinasController(ProjetoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Vacina>> Get(
        [FromQuery] string nomeFiltro,
        [FromQuery] int? numeroDosesFiltro
    )
    {
        //SELECT * FROM VACINAS WHERE NUMERODOSES = ?
        var query = _context.Vacinas.AsQueryable();

        if(!string.IsNullOrEmpty(nomeFiltro)){
            query = query.Where(v => v.Nome.Contains(nomeFiltro));
        }

        if(numeroDosesFiltro.HasValue && numeroDosesFiltro.Value > 0){
            query = query.Where(v => v.NumeroDoses == numeroDosesFiltro);
        }

        return Ok(
            query
            .OrderBy(v => v.Nome)
            .ToList()
        );
    }
}
