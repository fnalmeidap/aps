using Olimpo.Repository;
using Olimpo.Model;

namespace Olimpo.Repository
{
    public interface IRepositoryFactory
    {
        IRepository<Equipe> CreateEquipeMemoryRepository();
        IRepository<Equipe> CreateEquipeDatabaseRepository();
    }

    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<Equipe> CreateEquipeMemoryRepository()
        {
            return EquipesRepository.GetInstance();
        }

        public IRepository<Equipe> CreateEquipeDatabaseRepository()
        {
            throw new NotImplementedException();
        }
    }
}