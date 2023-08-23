using Microsoft.AspNetCore.Mvc;
using Olimpo.Controllers;
using Olimpo.Models;

namespace Web.Api
{
    [ApiController]
    [Route("/")]
    public class ApiRouter : ControllerBase
    {
        // Login

        // Participante
        [HttpGet]
        [Route("api/participante")]
        public IActionResult GetParticipanteList()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/participante/{id}")]
        public IActionResult GetParticipanteById(int Id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("api/participante")]
        public IActionResult CreateParticipante([FromBody] Participante participante)
        {
            if (participante == null)
            {
                return BadRequest("Invalid data.");
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/participante/{id}")]
        public IActionResult DeleteParticipanteById(int id)
        {
            Console.WriteLine(id);
            return NoContent();
        }

        // Equipe
        [HttpGet]
        [Route("api/equipe")]
        public IActionResult GetEquipeList()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/equipe/{id}")]
        public IActionResult GetEquipeById(int id)
        {   
            Console.WriteLine(id);
            return Ok();
        }

        [HttpPost]
        [Route("api/equipe")]
        public IActionResult CreateEquipe([FromBody] Equipe equipe)
        {
            if (equipe == null)
            {
                return BadRequest("Invalid data.");
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/equipe/{id}")]
        public IActionResult DeleteEquipeById(int id)
        {

            Console.WriteLine(id);
            return NoContent();
        }

        [HttpPatch]
        [Route("api/equipe")]
        public IActionResult AddParticipanteToEquipe([FromBody] ParticipanteEquipeRequest participanteEquipeRequest)
        {

            return NoContent();
        }

        // Evento

        // TDP
    }
}