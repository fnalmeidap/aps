using ServicoEvento.Controllers;
using ServicoEvento.Model;
using ServicoEvento.Repository;

namespace ServicoEvento.Web
{
    class Fachada
    {
        private EventoController eventoController = new EventoController();

       #region Evento
        public void cadastrarEvento(Evento evento)
        {
            eventoController.CreateEvento(evento);
        }

        public Evento buscarEvento(int id)
        {
            return eventoController.GetEventoById(id);
        }

        public IEnumerable<Evento> buscarTodosEventos()
        {
            return eventoController.GetEventosList();
        }

        public bool inscreverEquipeEvento(InscricaoEquipeRequest request)
        {
            return eventoController.AddEquipeToEvento(request);
        }

        public bool removerEvento(int Id)
        {
            return eventoController.DeleteEventoById(Id);
        }
        #endregion
    }
}