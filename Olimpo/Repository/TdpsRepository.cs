using Olimpo.Model;

namespace Olimpo.Repository;
public class TdpsRepository : IRepository<TDP>
{
    private static TdpsRepository Instance = null;
    private List<TDP> cadastroTdps { get; set; }

    public static TdpsRepository GetInstance()
    {
        if (Instance == null)
        {
            Instance = new TdpsRepository();
        }
        return Instance;
    }

    public TdpsRepository()
    {
        cadastroTdps = new List<TDP>();

    }

    public IEnumerable<TDP> List
    {
        get
        {
            return cadastroTdps;
        }

    }

    public void Add(TDP entity)
    {
        cadastroTdps.Add(entity);
    }

    public void Delete(TDP entity)
    {
        cadastroTdps.Remove(entity);
    }

    public void Update(TDP entity)
    {
        cadastroTdps.Remove(entity);
        cadastroTdps.Add(entity);
    }

    public TDP? FindById(int Id)
    {
        var result = (cadastroTdps.FirstOrDefault(p => p.Id == Id));
        return result;
    }
    public IEnumerable<TDP> FindAll(int Id)
    {
        var result = (cadastroTdps.FindAll(p => p.Id == Id));
        return result;
    }

    public TDP? FindByPredicate(Func<TDP, bool> predicate) {
        var result = (cadastroTdps.FirstOrDefault(predicate));
        return result;
    }
}
