using Olimpo.Controllers;
using Olimpo.Model;

namespace Olimpo.Web
{
    class Fachada
    {
        private ParticipanteController participanteController = new ParticipanteController();
        private EquipeController equipeController = new EquipeController();
        private EventoController eventoController = new EventoController();
        private TdpController tdpController = new TdpController();

        #region Participante
        public void cadastrarParticipante(Participante participante)
        {
            participanteController.CreateParticipante(participante);
        }

        public Participante buscarParticipante(int Id)
        {
            return participanteController.GetParticipanteById(Id);
        }

        public IEnumerable<Participante> buscarTodosParticipantes()
        {
            return participanteController.GetParticipanteList();
        }

        public bool removerParticipante(int Id)
        {
            return participanteController.DeleteParticipanteById(Id);
        }
        #endregion

        #region Equipe
        public void cadastrarEquipe(Equipe equipe)
        {
            equipeController.CreateEquipe(equipe);
        }

        public Equipe buscarEquipe(int Id)
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
        #endregion

        #region Evento
        public void cadastrarEvento()
        {
            throw new NotImplementedException();
        }

        public Evento buscarEvento()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> buscarTodosEventos()
        {
            throw new NotImplementedException();
        }

        public void inscreverEquipeEvento()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}