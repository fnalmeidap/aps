using Microsoft.AspNetCore.Mvc;
using Olimpo.Controllers;
using Olimpo.Model;
using Olimpo.Web.Model;

namespace Olimpo.Web
{
    [ApiController]
    [Route("/")]
    public class Api : ControllerBase
    {
        private static Fachada _fachada = new Fachada();
        [HttpPost]
        [Route("api/login")]
        public IActionResult LoginParticipante([FromBody] LoginRequest loginRequest)
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/participante")]
        public IActionResult GetParticipanteList()
        {
            var listaDeParticipantes = _fachada.buscarTodosParticipantes();

            if(listaDeParticipantes == null)
            {
                return NotFound();
            }
            
            return Ok(listaDeParticipantes);
        }

        [HttpGet]
        [Route("api/participante/{id}")]
        public IActionResult GetParticipanteById(int Id)
        {
            if(Id == null || Id < 0)
            {
                return BadRequest("Invalid data.");
            }

            var participante = _fachada.buscarParticipante(Id);
            if(participante == null)
            {
                return NotFound();
            }

            return Ok(participante);
        }

        [HttpPost]
        [Route("api/participante")]
        public IActionResult CreateParticipante([FromBody] Participante participante)
        {
            if(participante == null)
            {
                return BadRequest("Invalid data.");
            }

            _fachada.cadastrarParticipante(participante);

            return StatusCode(StatusCodes.Status201Created, participante);
        }

        [HttpDelete]
        [Route("api/participante/{id}")]
        public IActionResult DeleteParticipanteById(int id)
        {
            if (id == null || id < 0)
            {
                return BadRequest("Invalid Id.");
            }

            var isDeleted = _fachada.removerParticipante(id);
            if(!isDeleted)
            {
                return NotFound(id);
            }

            return NoContent();
        }
    }
}