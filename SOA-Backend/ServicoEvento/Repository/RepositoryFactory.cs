using ServicoEvento.Repository;
using ServicoEvento.Model;

namespace ServicoEvento.Repository
{
    public interface IRepositoryFactory
    {
        IRepository<Evento> CreateEventoMemoryRepository();
        IRepository<Evento> CreateEventoDatabaseRepository();
    }

    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<Evento> CreateEventoMemoryRepository()
        {
            return EventosRepository.GetInstance();
        }

        public IRepository<Evento> CreateEventoDatabaseRepository()
        {
            throw new NotImplementedException();
        }
    }
}