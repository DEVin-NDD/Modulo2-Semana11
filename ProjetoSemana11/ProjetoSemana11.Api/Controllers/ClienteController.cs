using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoSemana11.Data;
using ProjetoSemana11.DTOs;
using ProjetoSemana11.Models;
using ProjetoSemana11.ViewModels;

namespace ProjetoSemana11.Api.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClienteController : ControllerBase
{
    private readonly ProjetoDbContext _context;

    public ClienteController(ProjetoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Cliente>> Get(
        [FromQuery] DateTime? dataInicio,
        [FromQuery] DateTime? dataFim
    )
    {
        //SELECT * FROM CLIENTES WHERE NUMERODOSES = ?
        var query = _context.Clientes.AsQueryable();

        if (dataInicio.HasValue)
        {
            query = query.Where(c => c.DataNascimento >= dataInicio.Value);
        }

        if (dataFim.HasValue)
        {
            query = query.Where(c => c.DataNascimento <= dataFim.Value);
        }

        return Ok(
            query
            .Include(c => c.CarteiraTrabalho)
            .OrderBy(v => v.Nome)
            .ToList()
        );
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> GetById([FromRoute] int id)
    {
        return Ok(
            _context.Clientes
            .Include(c => c.CarteiraTrabalho)
            .FirstOrDefault(c => c.Id == id)
        );
    }

    [HttpGet("{id}/com-view-model")]
    public ActionResult<ClienteViewModel> GetByIdViewModel([FromRoute] int id)
    {
        return Ok(
            _context.Clientes
            .Include(c => c.CarteiraTrabalho)
            .Select(c => new ClienteViewModel{
                Id = c.Id,
                Nome = c.Nome,
                DataNascimento = c.DataNascimento,
                CarteiraTrabalho = c.CarteiraTrabalho == null ? null : new CarteiraTrabalhoViewModel{
                    Id = c.CarteiraTrabalho.Id,
                    PisPasep = c.CarteiraTrabalho.PisPasep
                }
            })
            .FirstOrDefault(c => c.Id == id)
        );
    }

    [HttpPost]
    public ActionResult<Cliente> Post(
        [FromBody] ClienteDTO body
    )
    {
        var cliente = new Cliente
        {
            Nome = body.Nome,
            DataNascimento = body.DataNascimento,
            CarteiraTrabalho = body.CarteiraTrabalho != null ? new CarteiraTrabalho
            {
                PisPasep = body.CarteiraTrabalho.PisPasep
            } : null
        };

        _context.Clientes.Add(cliente);

        _context.SaveChanges();

        return Created("api/clientes", cliente);
    }

    [HttpPut("{id}")]
    public ActionResult<Cliente> Put(
        [FromBody] ClienteDTO body,
        [FromRoute] int id
    )
    {
        var cliente = _context.Clientes
            .Include(c => c.CarteiraTrabalho)
            .FirstOrDefault(c => c.Id == id);

        cliente.Nome = body.Nome;
        cliente.DataNascimento = body.DataNascimento;

        if (body.CarteiraTrabalho != null)
        {
            (cliente.CarteiraTrabalho ??= new CarteiraTrabalho())
                .PisPasep = body.CarteiraTrabalho.PisPasep;
        }
        
        _context.SaveChanges();

        return Ok(cliente);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var cliente = _context.Clientes.Find(id);

        if (cliente == null) return NotFound();

        _context.Clientes.Remove(cliente);

        _context.SaveChanges();

        return NoContent();
    }
}
