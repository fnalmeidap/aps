using Microsoft.AspNetCore.Mvc;

namespace NetApi.Controllers;

using Eventos = List<Evento>;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private static Eventos cadastroEventos = new Eventos();

    [HttpGet(Name = "GetEventosList")]
    public Eventos GetEventosList()
    {
        return cadastroEventos;
    }

    [HttpGet("{id}", Name = "GetEventoById")]
    public ActionResult<Evento> GetEventoById(int Id)
    {
        var evento = cadastroEventos.FirstOrDefault(p => p.Id == Id);
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
        var participante = cadastroEventos.FirstOrDefault(p => p.Id == id);
        if (participante == null)
        {
            return NotFound();
        }

        cadastroEventos.Remove(participante);
        return NoContent();
    }
}

