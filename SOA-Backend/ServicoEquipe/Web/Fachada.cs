using Olimpo.Controllers;
using Olimpo.Model;
using Olimpo.Repository;

namespace Olimpo.Web
{
    class Fachada
    {
        private EquipeController equipeController = new EquipeController();

        public void cadastrarEquipe(Equipe equipe)
        {
            equipeController.CreateEquipe(equipe);
        }

        public Equipe? buscarEquipe(int Id)
        {
            return equipeController.GetEquipeById(Id);
        }

        public IEnumerable<Equipe> buscarTodasEquipes()
        {
            return equipeController.GetEquipeList();
        }

        public bool cadastrarParticipanteEmEquipe(ParticipanteEquipeRequest request)
        {
            return equipeController.AddParticipanteToEquipe(request);
        }

        public bool removerEquipe(int Id)
        {
            return equipeController.DeleteEquipeById(Id);
        }
    }
}