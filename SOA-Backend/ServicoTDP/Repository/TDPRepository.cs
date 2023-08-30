using ServicoTDP.Model;

namespace ServicoTDP.Repository;
public class TDPRepository : IRepository<TDP>
{
    private static TDPRepository Instance = null;
    private List<TDP> cadastroTDP { get; set; }

    public static TDPRepository GetInstance()
    {
        if (Instance == null)
        {
            Instance = new TDPRepository();
        }
        return Instance;
    }

    public TDPRepository()
    {
        cadastroTDP = new List<TDP>();

    }

    public IEnumerable<TDP> List
    {
        get
        {
            return cadastroTDP;
        }

    }

    public void Add(TDP entity)
    {
        cadastroTDP.Add(entity);
    }

    public void Delete(TDP entity)
    {
        cadastroTDP.Remove(entity);
    }

    public void Update(TDP entity)
    {
        cadastroTDP.Remove(entity);
        cadastroTDP.Add(entity);
    }

    public TDP? FindById(int Id)
    {
        var result = (cadastroTDP.FirstOrDefault(p => p.Id == Id));
        return result;
    }
    public IEnumerable<TDP> FindAll(int Id)
    {
        var result = (cadastroTDP.FindAll(p => p.Id == Id));
        return result;
    }

    public TDP? FindByPredicate(Func<TDP, bool> predicate) {
        var result = (cadastroTDP.FirstOrDefault(predicate));
        return result;
    }
}
