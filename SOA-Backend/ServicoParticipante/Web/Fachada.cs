using ServicoParticipante.Controllers;
using ServicoParticipante.Model;
using ServicoParticipante.Repository;

namespace ServicoParticipante.Web
{
    class Fachada
    {
        private ParticipanteController participanteController = new ParticipanteController();
        
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
    }
}