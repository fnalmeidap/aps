using Microsoft.AspNetCore.Mvc;
using Olimpo.Controllers;
using Olimpo.Model;
using Olimpo.Web.Model;

namespace Olimpo.Web
{
    [ApiController]
    [Route("/")]
    public class Api : ControllerBase
    {
        private static Fachada _fachada = new Fachada();

        [HttpGet]
        [Route("api/tdp")]
        public IActionResult GetTDPList()
        {
            return Ok(_fachada.listarTDPs());
        }

        [HttpGet]
        [Route("api/tdp/{equipeId}")]
        public IActionResult GetTDPByEquipe(int equipeId)
        {
            return Ok(_fachada.listarTDPByEquipe(equipeId));
        }

        [HttpGet]
        [Route("api/tdp/{equipeId}/{categoria}")]
        public IActionResult GetTDPByEquipeCategoria(int equipeId, CategoriasType categoria)
        {
            return Ok(_fachada.listarTDPByEquipeCategoria(equipeId, categoria));
        }

        //todo(fnap): fix route
        [HttpPost]
        [Route("api/tdp")]
        public IActionResult CreateTdp([FromBody] TDP tdp)
        {
            _fachada.cadastrarTDP(tdp);
            return Ok();
        }

        [HttpDelete]
        [Route("api/tdp/{equipeId}/{categoria}")]
        public IActionResult DeleteTdpById(int equipeId, CategoriasType categoria)
        {
            if (_fachada.deleteTDPByEquipeCategoria(equipeId, categoria))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}