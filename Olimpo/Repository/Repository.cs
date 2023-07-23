using Olimpo.Models;

namespace Olimpo.Repository
{
    public interface IRepository<T> where T : EntidadeBase
    {

        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T? FindById(int Id);
        IEnumerable<T> FindAll(int Id);

        T? FindByPredicate(Func<T, bool> predicate);
    }
}
