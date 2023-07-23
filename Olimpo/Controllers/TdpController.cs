using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace Olimpo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TdpController : ControllerBase
{
    private static IRepository<TDP> cadastroTdps= new TdpsRepository();
    private static int generateId = 0;

    [HttpGet(Name = "GetTDPList")]
    public IEnumerable<TDP> GetTDPList()
    {
        return cadastroTdps.List;
    }

    [HttpGet("{equipeId}", Name = "GetTDPByEquipe")]
    public ActionResult<TDP> GetTDPByEquipe(int equipeId)
    {
        Console.WriteLine(cadastroTdps.List.First().EquipeId);
        Console.WriteLine(equipeId);
        var equipeTdps = cadastroTdps.FindByPredicate(t => 
            t.EquipeId == equipeId);

        if (equipeTdps == null)
        {
            return NotFound();
        }

        return equipeTdps;
    }

    [HttpGet("{equipeId}/{categoria}", Name = "GetTDPByEquipeCategoria")]
    public ActionResult<TDP> GetTDPByEquipeCategoria(int equipeId, CategoriasType categoria)
    {
        var equipeTdps = cadastroTdps.FindByPredicate(t => 
            t.EquipeId == equipeId &&
            t.Categoria == categoria);

        if (equipeTdps == null)
        {
            return NotFound();
        }

        return equipeTdps;
    }

    [HttpPost(Name = "CreateTdp")]
    public IActionResult CreateTdp([FromBody] TDP tdp)
    {
        if (tdp == null)
        {
            return BadRequest("Invalid data.");
        }

        tdp.Id = generateId;
        generateId += 1;

        cadastroTdps.Add(tdp);

        return CreatedAtRoute("GetTDPList", null, tdp);
    }

    [HttpDelete("{equipeId}/{categoria}", Name = "DeleteTdpByEquipeCategoria")]
    public IActionResult DeleteTdpById(int equipeId, CategoriasType categoria)
    {
        var equipeTdps = cadastroTdps.FindByPredicate(t => 
            t.EquipeId == equipeId &&
            t.Categoria == categoria);

        if (equipeTdps == null)
        {
            return NotFound();
        }

        cadastroTdps.Delete(equipeTdps);
        return NoContent();
    }
}

