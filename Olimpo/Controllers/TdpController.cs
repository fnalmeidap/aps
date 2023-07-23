using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace NetApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TdpController : ControllerBase
{
    private static IRepository<TDP> cadastroTdps= new TdpsRepository();

    [HttpGet("{id}/{categoria}", Name = "GetTDPById")]
    public ActionResult<TDP> GetTDPById(int id, int categoria)
    {
        var equipeTdps = cadastroTdps.FindAll(id);
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

        cadastroTdps.Add(tdp);

        return CreatedAtRoute("GetTdpList", null, tdp);
    }

    [HttpDelete("{id}/{categoria}", Name = "DeleteTdpById")]
    public IActionResult DeleteTdpById(int id, int categoria)
    {
        var equipeTdps = cadastroTdps.FindAll(id);
        if (equipeTdps == null)
        {
            return NotFound();
        }

        var tdp = equipeTdps.FirstOrDefault(p => p.Categoria == (CategoriasType)categoria);
        if (tdp == null)
        {
            return NotFound();
        }

        cadastroTdps.Delete(tdp);
        return NoContent();
    }
}

