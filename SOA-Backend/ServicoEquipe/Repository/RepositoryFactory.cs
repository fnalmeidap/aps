using ServicoEquipe.Repository;
using ServicoEquipe.Model;

namespace ServicoEquipe.Repository
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