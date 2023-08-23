using Microsoft.AspNetCore.Mvc;
using Olimpo.EquipeService.Model;

namespace Olimpo.EquipeService.Web
{
    public class ParticipanteEquipeRequest
    {
        public int EquipeId { get; set; }
        public int ParticipanteId { get; set; }
    }

    [ApiController]
    [Route("api/equipe")]
    public class EquipeHandler : ControllerBase
    {
        // private EquipeController equipeController = new EquipeController();

        // [HttpGet(Name = "GetEquipeList")]
        // public IEnumerable<Equipe> GetEquipeList()
        // {
        //     return equipeController.GetEquipeList();
        // }

        // [HttpGet("{id}", Name = "GetEquipeById")]
        // public ActionResult<Equipe> GetEquipeById(int id)
        // {
        //     var equipe = equipeController.GetEquipeById(id);
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

        //     equipeController.CreateEquipe(equipe);

        //     return CreatedAtRoute("GetEquipeList", null, equipe);
        // }

        // [HttpDelete("{id}", Name = "DeleteEquipeById")]
        // public IActionResult DeleteEquipeById(int id)
        // {
        //     if (!equipeController.DeleteEquipeById(id))
        //     {
        //         return NotFound();
        //     }

        //     return NoContent();
        // }

        // [HttpPatch(Name = "AddParticipanteToEquipe")]
        // public IActionResult AddParticipanteToEquipe([FromBody] ParticipanteEquipeRequest participanteEquipeRequest)
        // {
        //     if (!equipeController.AddParticipanteToEquipe(participanteEquipeRequest))
        //     {
        //         return NotFound();
        //     }
        //     return NoContent();
        // }

    }
}
