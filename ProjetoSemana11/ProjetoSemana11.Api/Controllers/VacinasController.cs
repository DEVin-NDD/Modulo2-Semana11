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

    [HttpGet("{id}")]
    public ActionResult<Vacina> GetById([FromRoute] int id){
        return Ok(_context.Vacinas.Find(id));
    }

    [HttpPost]
    public ActionResult<Vacina> Post(
        [FromBody] Vacina body
    ){
        _context.Vacinas.Add(body);

        var operacoesRealizadas = _context.SaveChanges();

        if(operacoesRealizadas == 0){
            return new StatusCodeResult(500);
        }

        return Created("api/vacinas", body);
    }

    [HttpPut("{id}")]
    public ActionResult<Vacina> Put(
        [FromBody] Vacina body,
        [FromRoute] int id
    ){
        var vacina = _context.Vacinas.Find(id);

        if(vacina == null) return NotFound();

        vacina.Nome = body.Nome;
        vacina.NumeroDoses = body.NumeroDoses;

        _context.SaveChanges();

        return Ok(vacina);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id){
        var vacina = _context.Vacinas.Find(id);

        if(vacina == null) return NotFound();

        _context.Vacinas.Remove(vacina);

        var operacoesRealizadas = _context.SaveChanges();
        if(operacoesRealizadas == 0){
            return new StatusCodeResult(500);
        }

        return NoContent();
    }
}
