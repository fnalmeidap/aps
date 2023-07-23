using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace Olimpo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipeController : ControllerBase
{
    private static IRepository<Equipe> cadastroEquipes = new EquipesRepository();

    [HttpGet(Name = "GetEquipeList")]
    public List<Equipe> GetEquipeList()
    {
        return (List<Equipe>)cadastroEquipes;
    }

    [HttpGet("{id}", Name = "GetEquipeByName")]
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
