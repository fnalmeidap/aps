using Microsoft.AspNetCore.Mvc;
using Olimpo;

namespace NetApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipeController : ControllerBase
{
    private static List<Equipe> equipes = new List<Equipe>();

    [HttpGet(Name = "GetEquipeList")]
    public List<Equipe> GetEquipeList()
    {
        return equipes;
    }

    [HttpGet("{name}", Name = "GetEquipeByName")]
    public ActionResult<Equipe> GetEquipeById(string Name)
    {
        var equipe = equipes.FirstOrDefault(e => e.Name == Name);
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
      
        equipes.Add(equipe);

        return CreatedAtRoute("GetEquipeList", null, equipe);
    }

    [HttpDelete("{id}", Name = "DeleteEquipeById")]
    public IActionResult DeleteEquipeById(string Name)
    {
        var equipe = equipes.FirstOrDefault(p => p.Name.ToLower() == Name.ToLower());
        if (equipe == null)
        {
            return NotFound();
        }

        equipes.Remove(equipe);
        return NoContent();
    }
}
