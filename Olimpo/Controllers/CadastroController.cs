using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace Olimpo.Controllers
{
    public class LoginController
    {
        private static IRepository<Participante> cadastroParticipantes = ParticipantesRepository.GetInstance();
        private static IRepository<Equipe> cadastroEquipes = EquipesRepository.GetInstance();

        public ActionResult<ParticipanteEquipe>? ValidadeParticipanteByToken(string tokenId)
        {
            var participante = cadastroParticipantes.FindByPredicate(e => e.TokenId == tokenId);
            if (participante == null)
            {
                return null;
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
