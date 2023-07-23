using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace Olimpo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipeController : ControllerBase
{
    private static IRepository<Equipe> cadastroEquipes = new EquipesRepository();
    private static IRepository<Participante> cadastroParticipantes = new ParticipantesRepository();

    [HttpGet(Name = "GetEquipeList")]
    public IEnumerable<Equipe> GetEquipeList()
    {
        return cadastroEquipes.List;
    }

    [HttpGet("{id}", Name = "GetEquipeById")]
    public ActionResult<Equipe> GetEquipeById(int id)
    {
        var equipe = cadastroEquipes.FindById(id);
        if (equipe == null)
        {
            return NotFound();
        }
        return equipe;
    }

    [HttpPost(Name = "CreateEquipe")]
    public IActionResult CreateEquipe([FromBody]Equipe equipe)
    {
        if (equipe == null)
        {
            return BadRequest("Invalid data.");
        }

        List<Participante> validMembers = new List<Participante>();
        foreach (var member in equipe.Members) {
            var participante = cadastroParticipantes.FindById(member.Id);
            if (participante != null) {
                validMembers.Add(participante);
            }
        }
        equipe.Members = validMembers;  

        cadastroEquipes.Add(equipe);

        return CreatedAtRoute("GetEquipeList", null, equipe);
    }

    [HttpDelete("{id}", Name = "DeleteEquipeById")]
    public IActionResult DeleteEquipeById(int id)
    {
        var equipe = cadastroEquipes.FindById(id);
        if (equipe == null)
        {
            return NotFound();
        }

        cadastroEquipes.Delete(equipe);
        return NoContent();
    }
}
