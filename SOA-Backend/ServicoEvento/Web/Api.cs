using Microsoft.AspNetCore.Mvc;
using ServicoEvento.Controllers;
using ServicoEvento.Model;
using ServicoEvento.Web.Model;

namespace ServicoEvento.Web
{
    [ApiController]
    [Route("/")]
    public class Api : ControllerBase
    {
        private static Fachada _fachada = new Fachada();
        
        [HttpGet]
        [Route("api/evento")]
        public IActionResult GetEventosList()
        {
            var listaDeEventos = _fachada.buscarTodosEventos();
            if(listaDeEventos == null)
            {
                return NotFound();
            }

            return Ok(listaDeEventos);
        }

        [HttpGet]
        [Route("api/evento/{id}")]
        public IActionResult GetEventoById(int id)
        {
            if(id == null || id < 0)
            {
                return NotFound();
            }
            
            var evento = _fachada.buscarEvento(id);
            if(evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        [HttpPost]
        [Route("api/evento")]
        public IActionResult CreateEvento([FromBody] Evento evento)
        {
            if (evento == null)
            {
                return BadRequest("Invalid data.");
            }

            _fachada.cadastrarEvento(evento);

            return StatusCode(StatusCodes.Status201Created, evento);
        }

        [HttpDelete]
        [Route("api/evento/{id}")]
        public IActionResult DeleteEventoById(int id)
        {
            if(id == null || id < 0)
            {
                return BadRequest("Invalid Id");
            }

            var isDeleted = _fachada.removerEvento(id);
            if(!isDeleted)
            {
                return NotFound(id);
            }

            return NoContent();
        }

        [HttpPatch]
        [Route("api/evento")]
        public IActionResult AddEquipeToEvento([FromBody] InscricaoEquipeRequest equipeData)
        {
            if(equipeData == null)
            {
                return BadRequest("Invalid request");
            }

            var isAdicionado = _fachada.inscreverEquipeEvento(equipeData);
            if(!isAdicionado)
            {
                return NoContent();
            }

            return StatusCode(StatusCodes.Status201Created, equipeData);
        }

       
    }
}