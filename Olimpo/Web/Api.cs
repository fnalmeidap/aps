using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
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
        #region Login
        [HttpGet]
        [Route("api/login/{tokenId}")]
        public IActionResult LoginParticipante([FromBody] string tokenId)
        {
            var isLoggedIn = _fachada.logarParticipante(tokenId);
            if(isLoggedIn)
            {
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region Participante
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
            if(request == null)
            {
                return BadRequest("Invalid data.");
            }

            var isCreated = _fachada.cadastrarParticipante(request);
            if(isCreated)
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
        #endregion

        #region Equipe
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
        #endregion

        #region Evento
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
        #endregion

        #region TDP
        [HttpGet]
        [Route("api/tdp")]
        public IActionResult GetTDPList()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/tdp/{equipeId}")]
        public IActionResult GetTDPByEquipe(int equipeId)
        {
            Console.WriteLine(equipeId);

            return Ok();
        }

        [HttpGet]
        [Route("api/tdp/{equipeId}/{categoria}")]
        public IActionResult GetTDPByEquipeCategoria(int equipeId, CategoriasType categoria)
        {
            Console.WriteLine("equipeId: {0}\ncategoria: {1}", equipeId, categoria);
            return Ok();
        }

        //todo(fnap): fix route
        [HttpPost]
        [Route("api/tdp")]
        public IActionResult CreateTdp([FromBody] TDP tdp)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("api/tdp/{equipeId}/{categoria}")]
        public IActionResult DeleteTdpById(int equipeId, CategoriasType categoria)
        {
            Console.WriteLine("equipeId: {0}\ncategoria: {1}", equipeId, categoria);
            return NoContent();
        }
        #endregion
    }
}