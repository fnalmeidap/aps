using Olimpo.Repository;
using Olimpo.Model;

namespace Olimpo.Repository
{
    public interface IRepositoryFactory
    {
        IRepository<TDP> CreateTDPMemoryRepository();
        IRepository<TDP> CreateTDPDatabaseRepository();
    }

    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<TDP> CreateTDPMemoryRepository()
        {
            return TDPRepository.GetInstance();
        }

        public IRepository<TDP> CreateTDPDatabaseRepository()
        {
            throw new NotImplementedException();
        }
    }
}