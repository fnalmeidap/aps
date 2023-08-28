using Olimpo.Controllers;
using Olimpo.Model;

namespace Olimpo.Web
{
    class Fachada
    {
        private ParticipanteController participanteController;
        private EquipeController equipeController;
        private EventoController eventoController;
        private TdpController tdpController;

        #region Participante
        public void cadastrarParticipante()
        {
            participanteController.;
        }

        public Participante buscarParticipante()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participante> buscarTodosParticipantes()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Equipe
        public void cadastrarEquipe()
        {
            throw new NotImplementedException();
        }

        public Equipe buscarEquipe()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipe> buscarTodasEquipes()
        {
            throw new NotImplementedError();
        }

        public void cadastrarParticipanteEmEquipe()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedError();
        }

        public void inscreverEquipeEvento()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}