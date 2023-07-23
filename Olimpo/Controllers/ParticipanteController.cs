using Microsoft.AspNetCore.Mvc;

namespace NetApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticipanteController : ControllerBase
{
    private static List<Participante> participantes = new List<Participante>();

    [HttpGet(Name = "GetParticipanteList")]
    public List<Participante> GetParticipanteList()
    {
        return participantes;
    }

    [HttpGet("{id}", Name = "GetParticipanteById")]
    public ActionResult<Participante> GetParticipanteById(int Id)
    {
        var participante = participantes.FirstOrDefault(p => p.Id == Id);
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
      
        participantes.Add(participante);
        Console.WriteLine(participantes.Count);

        return CreatedAtRoute("GetParticipanteList", null, participante);
    }

    [HttpDelete("{id}", Name = "DeleteParticipanteById")]
    public IActionResult DeleteParticipanteById(int id)
    {
        var participante = participantes.FirstOrDefault(p => p.Id == id);
        if (participante == null)
        {
            return NotFound();
        }

        participantes.Remove(participante);
        return NoContent();
    }
}
