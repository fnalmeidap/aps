using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace Olimpo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipeController : ControllerBase
{
    private static IRepository<Equipe> cadastroEquipes = EquipesRepository.GetInstance();
    private static IRepository<Participante> cadastroParticipantes = ParticipantesRepository.GetInstance();

    private static int generateId = 0;

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

        equipe.Id = generateId;
        generateId += 1;

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

    [HttpPatch(Name = "AddParticipanteToEquipe")]
    public IActionResult AddParticipanteToEquipe([FromBody] ParticipanteData participanteData)
    {
        var equipeId = participanteData.EquipeId;
        var participanteId = participanteData.ParticipanteId;

        var equipe = cadastroEquipes.FindById(equipeId);
        if (equipe == null)
        {
            return NotFound();
        }

        var participante = cadastroParticipantes.FindById(participanteId);
        if (participante == null)
        {
            return NotFound();
        }

        equipe.Members.Add(participante);
        cadastroEquipes.Update(equipe);

        return NoContent();
    }
}
