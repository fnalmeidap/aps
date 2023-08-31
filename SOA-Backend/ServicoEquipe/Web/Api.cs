using Microsoft.AspNetCore.Mvc;
using ServicoEquipe.Controllers;
using ServicoEquipe.Model;

namespace ServicoEquipe.Web
{
    [ApiController]
    [Route("/")]
    public class Api : ControllerBase
    {
        private static Fachada _fachada = new Fachada();
        
        [HttpGet]
        [Route("api/equipe")]
        public IActionResult GetEquipeList()
        {
            var listaDeEquipes = _fachada.buscarTodasEquipes();

            if(listaDeEquipes == null)
            {
                return NotFound();
            }

            return Ok(listaDeEquipes);
        }

        [HttpGet]
        [Route("api/equipe/{id}")]
        public IActionResult GetEquipeById(int id)
        {   
            if(id == null || id < 0)
            {
                return NotFound();
            }
            
            var equipe = _fachada.buscarEquipe(id);
            if(equipe == null)
            {
                return NotFound();
            }

            return Ok(equipe);
        }

        [HttpPost]
        [Route("api/equipe")]
        public IActionResult CreateEquipe([FromBody] Equipe equipe)
        {
            if (equipe == null)
            {
                return BadRequest("Invalid data.");
            }

            _fachada.cadastrarEquipe(equipe);

            return StatusCode(StatusCodes.Status201Created, equipe);
        }

        [HttpDelete]
        [Route("api/equipe/{id}")]
        public IActionResult DeleteEquipeById(int id)
        {
            if(id == null || id < 0)
            {
                return BadRequest("Invalid Id");
            }

            var isDeleted = _fachada.removerEquipe(id);
            if(!isDeleted)
            {
                return NotFound(id);
            }

            return NoContent();
        }

        [HttpPatch]
        [Route("api/equipe")]
        public IActionResult AddParticipanteToEquipe([FromBody] ParticipanteEquipeRequest participanteEquipeRequest)
        {
            if(participanteEquipeRequest == null)
            {
                return BadRequest("Invalid request");
            }

            var isAdicionado = _fachada.cadastrarParticipanteEmEquipe(participanteEquipeRequest);
            if(!isAdicionado)
            {
                return NoContent();
            }

            return StatusCode(StatusCodes.Status201Created, participanteEquipeRequest);
        }
    }
}