using Microsoft.AspNetCore.Mvc;
using Olimpo.Controllers;
using Olimpo.Models;

namespace Olimpo.Views
{
    [ApiController]
    [Route("api/participante")]
    public class ParticipanteHandler : ControllerBase
    {
        private ParticipanteController participanteController = new ParticipanteController();

        [HttpGet(Name = "GetParticipanteList")]
        public IEnumerable<Participante> GetParticipanteList()
        {
            return participanteController.GetParticipanteList();
        }

        [HttpGet("{id}", Name = "GetParticipanteById")]
        public ActionResult<Participante> GetParticipanteById(int Id)
        {
            var participante = participanteController.GetParticipanteById(Id);
            if (participante == null)
            {
                return NotFound();
            }
            return participante;
        }

        [HttpPost(Name = "CreateParticipante")]
        public IActionResult CreateParticipante([FromBody] Participante participante)
        {
            if (participante == null)
            {
                return BadRequest("Invalid data.");
            }
            participanteController.CreateParticipante(participante);

            return CreatedAtRoute("GetParticipanteList", null, participante);
        }

        [HttpDelete("{id}", Name = "DeleteParticipanteById")]
        public IActionResult DeleteParticipanteById(int id)
        {
            if (!participanteController.DeleteParticipanteById(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
