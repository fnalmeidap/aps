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
            throw new NotImplementedException();
        }

        public Participante buscarParticipante()
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

        public void inscreverEquipeEvento()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}