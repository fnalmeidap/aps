using Microsoft.AspNetCore.Mvc;
using Olimpo.Controllers;
using Olimpo.Models;

namespace Olimpo.Views
{
    [ApiController]
    [Route("api/tdp")]
    public class TDPHandler : ControllerBase
    {
        private TdpController tdpController = new TdpController();

        [HttpGet(Name = "GetTDPList")]
        public IEnumerable<TDP> GetTDPList()
        {
            return tdpController.GetTDPList();
        }

        [HttpGet("{equipeId}", Name = "GetTDPByEquipe")]
        public ActionResult<TDP> GetTDPByEquipe(int equipeId)
        {
            var equipeTdps = tdpController.GetTDPByEquipe(equipeId);

            if (equipeTdps == null)
            {
                return NotFound();
            }

            return equipeTdps;
        }

        [HttpGet("{equipeId}/{categoria}", Name = "GetTDPByEquipeCategoria")]
        public ActionResult<TDP> GetTDPByEquipeCategoria(int equipeId, CategoriasType categoria)
        {
            var equipeTdps = tdpController.GetTDPByEquipeCategoria(equipeId, categoria);

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

            tdpController.CreateTdp(tdp);
            return CreatedAtRoute("GetTDPList", null, tdp);
        }

        [HttpDelete("{equipeId}/{categoria}", Name = "DeleteTdpByEquipeCategoria")]
        public IActionResult DeleteTdpById(int equipeId, CategoriasType categoria)
        {
            if (!tdpController.DeleteTdpById(equipeId, categoria))
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
