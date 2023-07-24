using Microsoft.AspNetCore.Mvc;
using Olimpo.Controllers;
using Olimpo.Models;

namespace Olimpo.Views
{
    [ApiController]
    [Route("api/eventos")]
    public class EventosHandler : ControllerBase
    {
        private EventosController eventoController = new EventosController();

        [HttpGet(Name = "GetEventosList")]
        public IEnumerable<Evento> GetEventosList()
        {
            return eventoController.GetEventosList();
        }

        [HttpGet("{id}", Name = "GetEventoById")]
        public ActionResult<Evento> GetEventoById(int Id)
        {
            var evento = eventoController.GetEventoById(Id);
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

            eventoController.CreateEvento(evento);

            return CreatedAtRoute("GetEventosList", null, evento);
        }

        [HttpDelete("{id}", Name = "DeleteEventoById")]
        public IActionResult DeleteEventoById(int id)
        {
            var participante = eventoController.DeleteEventoById(id);
            if (participante == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPatch(Name = "AddEquipeToEvento")]
        public IActionResult AddEquipeToEvento([FromBody] EquipeData equipeData)
        {
            if (!eventoController.AddEquipeToEvento(equipeData))
            {
                return BadRequest("Invalid data.");
            }

            return NoContent();
        }

    }
}
