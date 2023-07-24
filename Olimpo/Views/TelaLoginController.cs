using Microsoft.AspNetCore.Mvc;
using Olimpo.Controllers;
using Olimpo.Models;

namespace Olimpo.Views
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelaLoginController : ControllerBase
    {
        private ParticipanteController participanteController = new ParticipanteController();
        private EquipeController equipeController = new EquipeController();

        [HttpGet("{tokenId}", Name = "ValidadeParticipanteByToken")]
        public ActionResult<ParticipanteEquipe> ValidadeParticipanteByToken(string tokenId)
        {
            var participante = participanteController.GetParticipanteList().FirstOrDefault(e => e.TokenId == tokenId);
            if (participante == null)
            {
                return NotFound();
            }

            Equipe? pEquipe = null;
            foreach (var equipe in equipeController.GetEquipeList())
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
