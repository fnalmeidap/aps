using Microsoft.AspNetCore.Mvc;
using Olimpo;

namespace NetApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TdpController : ControllerBase
{
    private static List<TDP> cadastroTDPs = new List<TDP>();

    [HttpGet("{id}/{categoria}", Name = "GetTDPById")]
    public ActionResult<TDP> GetTDPById(int id, int categoria)
    {
        var equipeTdps = cadastroTDPs.FindAll(p => p.EquipeId == id);
        if (equipeTdps == null)
        {
            return NotFound();
        }

        var tdp = equipeTdps.FirstOrDefault(p => p.Categoria == (CategoriasType)categoria);
        if (tdp == null)
        {
            return NotFound();
        }

        return tdp;
    }

    [HttpPost(Name = "CreateTdp")]
    public IActionResult CreateTdp([FromBody] TDP tdp)
    {
        if (tdp == null)
        {
            return BadRequest("Invalid data.");
        }

        cadastroTDPs.Add(tdp);

        return CreatedAtRoute("GetTdpList", null, tdp);
    }

    [HttpDelete("{id}/{categoria}", Name = "DeleteTdpById")]
    public IActionResult DeleteTdpById(int id, int categoria)
    {
        var equipeTdps = cadastroTDPs.FindAll(p => p.EquipeId == id);
        if (equipeTdps == null)
        {
            return NotFound();
        }

        var tdp = equipeTdps.FirstOrDefault(p => p.Categoria == (CategoriasType)categoria);
        if (tdp == null)
        {
            return NotFound();
        }

        var participante = cadastroTDPs.FirstOrDefault(p => p.Categoria == (CategoriasType)categoria);
        if (participante == null)
        {
            return NotFound();
        }

        cadastroTDPs.Remove(tdp);
        return NoContent();
    }
}

