using System.Net;
using Microsoft.AspNetCore.Mvc;
using Olimpo.ParticipanteService.Models;

namespace Olimpo.ParticipanteService.Web
{
    public class ParticipanteEquipeRequest
    {
        public int EquipeId { get; set; }
        public int ParticipanteId { get; set; }
    }
    
    [ApiController]
    [Route("/")]
    public class EquipeHandler : ControllerBase
    {   
        [Route("api/equipe")]
        [HttpGet()]
        public IActionResult GetEquipes(){
            return Ok();
        }
        // //todo: implementar comunicação com serviço de equipe via rabbitMQ
        // private EquipeServiceImpl equipeService;

        // [HttpGet(Name = "GetEquipeList")]
        // public IEnumerable<Equipe> GetEquipeList()
        // {
        //     return equipeService.GetEquipeList();
        // }

        // [HttpGet("{id}", Name = "GetEquipeById")]
        // public ActionResult<Equipe> GetEquipeById(int id)
        // {
        //     var equipe = equipeService.GetEquipeById(id);
        //     if (equipe == null)
        //     {
        //         return NotFound();
        //     }
        //     return equipe;
        // }

        // [HttpPost(Name = "CreateEquipe")]
        // public IActionResult CreateEquipe([FromBody] Equipe equipe)
        // {
        //     if (equipe == null)
        //     {
        //         return BadRequest("Invalid data.");
        //     }

        //     equipeService.CreateEquipe(equipe);

        //     return CreatedAtRoute("GetEquipeList", null, equipe);
        // }

        // [HttpDelete("{id}", Name = "DeleteEquipeById")]
        // public IActionResult DeleteEquipeById(int id)
        // {
        //     if (!equipeService.DeleteEquipeById(id))
        //     {
        //         return NotFound();
        //     }

        //     return NoContent();
        // }

        // [HttpPatch(Name = "AddParticipanteToEquipe")]
        // public IActionResult AddParticipanteToEquipe([FromBody] ParticipanteEquipeRequest participanteEquipeRequest)
        // {
        //     if (!equipeService.AddParticipanteToEquipe(participanteEquipeRequest))
        //     {
        //         return NotFound();
        //     }
        //     return NoContent();
        // }

    }
}