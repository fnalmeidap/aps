using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace NetApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private static IRepository<Evento> cadastroEventos = new EventosRepository();

    [HttpGet(Name = "GetEventosList")]
    public List<Evento> GetEventosList()
    {
        return (List<Evento>)cadastroEventos;
    }

    [HttpGet("{id}", Name = "GetEventoById")]
    public ActionResult<Evento> GetEventoById(int Id)
    {
        var evento = cadastroEventos.FindById(Id);
        if (evento == null)
        {
            return NotFound();
        }
        return evento;
    }

    [HttpPost(Name = "CreateEvento")]
    public IActionResult CreateEvento([FromBody] Evento evento)
    {
        if (evento == null)
        {
            return BadRequest("Invalid data.");
        }

        cadastroEventos.Add(evento);

        return CreatedAtRoute("GetEventoList", null, evento);
    }

    [HttpDelete("{id}", Name = "DeleteEventoById")]
    public IActionResult DeleteEventoById(int id)
    {
        var participante = cadastroEventos.FindById(id);
        if (participante == null)
        {
            return NotFound();
        }

        cadastroEventos.Delete(participante);
        return NoContent();
    }
}

