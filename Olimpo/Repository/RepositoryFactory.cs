using Olimpo.Repository;
using Olimpo.Model;

namespace Olimpo.Repository
{
    public interface IRepositoryFactory
    {
        IRepository<Participante> CreateParticipanteMemoryRepository();
        IRepository<Participante> CreateParticipanteDatabaseRepository();

        IRepository<Equipe> CreateEquipeMemoryRepository();
        IRepository<Equipe> CreateEquipeDatabaseRepository();

        IRepository<Evento> CreateEventoMemoryRepository();
        IRepository<Evento> CreateEventoDatabaseRepository();
    }

    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<Participante> CreateParticipanteMemoryRepository()
        {
            return ParticipantesRepository.GetInstance();
        }

        public IRepository<Participante> CreateParticipanteDatabaseRepository()
        {
            throw new NotImplementedException();
        }

        public IRepository<Equipe> CreateEquipeMemoryRepository()
        {
            return EquipesRepository.GetInstance();
        }

        public IRepository<Equipe> CreateEquipeDatabaseRepository()
        {
            throw new NotImplementedException();
        }

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