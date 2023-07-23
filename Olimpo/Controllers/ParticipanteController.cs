using Microsoft.AspNetCore.Mvc;
using Olimpo.Repository;
using Olimpo.Models;

namespace Olimpo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticipanteController : ControllerBase
{
    private static IRepository<Participante> cadastroParticipantes = new ParticipantesRepository();

    [HttpGet(Name = "GetParticipanteList")]
    public List<Participante> GetParticipanteList()
    {
        return (List<Participante>)cadastroParticipantes.List;
    }

    [HttpGet("{id}", Name = "GetParticipanteById")]
    public ActionResult<Participante> GetParticipanteById(int Id)
    {
        var participante = cadastroParticipantes.FindById(Id);
        if (participante == null)
        {
            return NotFound();
        }
        return participante;
    }

    [HttpPost(Name = "CreateParticipante")]
    public IActionResult CreateParticipante([FromBody]Participante participante)
    {
        if (participante == null)
        {
            return BadRequest("Invalid data.");
        }

        cadastroParticipantes.Add(participante);

        return CreatedAtRoute("GetParticipanteList", null, participante);
    }

    [HttpDelete("{id}", Name = "DeleteParticipanteById")]
    public IActionResult DeleteParticipanteById(int id)
    {
        var participante = cadastroParticipantes.FindById(id);
        if (participante == null)
        {
            return NotFound();
        }

        cadastroParticipantes.Delete(participante);
        return NoContent();
    }
}
