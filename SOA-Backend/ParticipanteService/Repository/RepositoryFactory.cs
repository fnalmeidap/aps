using Olimpo.Repository;
using Olimpo.Model;

namespace Olimpo.Repository
{
    public interface IRepositoryFactory
    {
        IRepository<Participante> CreateParticipanteMemoryRepository();
        IRepository<Participante> CreateParticipanteDatabaseRepository();
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
    }
}