using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace Olimpo.Controllers
{
    public class LoginResponse
    {
        public Participante? Participante { get;  set; }

        public Equipe? Equipe { get;  set; }

        public LoginResponse(Participante participante, Equipe equipe) { 
            Participante = participante;
            Equipe = equipe;

        }
    }

    public class CadastroController
    {
        private static IRepository<Participante> cadastroParticipantes = ParticipantesRepository.GetInstance();
        private static IRepository<Equipe> cadastroEquipes = EquipesRepository.GetInstance();

        public ActionResult<LoginResponse>? ValidadeParticipanteByToken(string tokenId)
        {
            var participante = cadastroParticipantes.FindByPredicate(e => e.TokenId == tokenId);
            if (participante == null)
            {
                return null;
            }

            Equipe? equipeDoParticipante = null;
            foreach (var equipe in cadastroEquipes.List)
            {
                foreach (var membro in equipe.Members)
                {
                    if (membro.Id == participante.Id)
                    {
                        equipeDoParticipante = equipe; break;
                    }
                }
            }   

            return new LoginResponse(participante, equipeDoParticipante);
        }
    }
}
