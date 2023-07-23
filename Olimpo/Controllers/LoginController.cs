using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace Olimpo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private static IRepository<Participante> cadastroParticipantes = new ParticipantesRepository();
        private static IRepository<Equipe> cadastroEquipes = new EquipesRepository();

        [HttpGet("{tokenId}", Name = "ValidadeParticipanteByToken")]
        public ActionResult<ParticipanteEquipe> ValidadeParticipanteByToken(string tokenId)
        {
            var participante = cadastroParticipantes.FindByPredicate(e => e.TokenId == tokenId);
            if (participante == null)
            {
                return NotFound();
            }

            Equipe? pEquipe = null;
            foreach (var equipe in cadastroEquipes.List)
            {
                foreach (var membro in equipe.Members)
                {
                    if (membro.Id == participante.Id)
                    {
                        pEquipe = equipe; break;
                    }
                }
            }

            return new ParticipanteEquipe(participante, pEquipe);
        }
    }
}
