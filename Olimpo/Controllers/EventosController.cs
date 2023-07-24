using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace Olimpo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private static IRepository<Evento> cadastroEventos = EventosRepository.GetInstance();
    private static IRepository<Equipe> cadastroEquipes = EquipesRepository.GetInstance();

    [HttpGet(Name = "GetEventosList")]
    public IEnumerable<Evento> GetEventosList()
    {
        return cadastroEventos.List;
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

        return CreatedAtRoute("GetEventosList", null, evento);
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

    [HttpPatch(Name = "AddEquipeToEvento")]
    public IActionResult AddEquipeToEvento([FromBody] EquipeData equipeData)
    {
        var eventoId = equipeData.EventoId;
        var equipeId = equipeData.EquipeId;
        var categorias = equipeData.Categorias;

        var evento = cadastroEventos.FindById(eventoId);
        if (evento == null)
        {
            return NotFound();
        }

        var equipe = cadastroEquipes.FindById(equipeId);
        if (equipe == null)
        {
            return NotFound();
        }

        if(categorias == null || categorias.Count == 0) {
            return BadRequest("Invalid data.");
        }

        evento.Equipes.Add(equipeData);
        cadastroEventos.Update(evento);

        return NoContent();
    }
        
}

