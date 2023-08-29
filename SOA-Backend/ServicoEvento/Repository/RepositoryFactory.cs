using Olimpo.Repository;
using Olimpo.Model;

namespace Olimpo.Repository
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