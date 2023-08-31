using Microsoft.AspNetCore.Mvc;
using ServicoParticipante.Controllers;
using ServicoParticipante.Model;
using Olimpo.Web.Model;

namespace ServicoParticipante.Web
{
    [ApiController]
    [Route("/")]
    public class Api : ControllerBase
    {
        private static Fachada _fachada = new Fachada();
        [HttpGet]
        [Route("api/login/{tokenId}")]
        public IActionResult LoginParticipante(string tokenId)
        {
            var participante = _fachada.logarParticipante(tokenId);
            if(participante == null)
            {
                return BadRequest();
            }

            return Ok(participante);
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
        public IActionResult CreateParticipante([FromBody] Participante request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            var isCreated = _fachada.cadastrarParticipante(request);
            if (isCreated)
            {
                return StatusCode(StatusCodes.Status201Created, request);
            }

            return NoContent();
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