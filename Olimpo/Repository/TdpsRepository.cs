using Olimpo.Models;

namespace Olimpo.Repository;
public class TdpsRepository : IRepository<TDP>
{

    private static List<TDP> cadatroTdps { get; set; }

    public TdpsRepository()
    {
        cadatroTdps = new List<TDP>();

    }

    public IEnumerable<TDP> List
    {
        get
        {
            return cadatroTdps;
        }

    }

    public void Add(TDP entity)
    {
        cadatroTdps.Add(entity);
    }

    public void Delete(TDP entity)
    {
        cadatroTdps.Remove(entity);
    }

    public void Update(TDP entity)
    {
        cadatroTdps.Remove(entity);
        cadatroTdps.Add(entity);
    }

    public TDP? FindById(int Id)
    {
        var result = (cadatroTdps.FirstOrDefault(p => p.Id == Id));
        return result;
    }
    public IEnumerable<TDP> FindAll(int Id)
    {
        var result = (cadatroTdps.FindAll(p => p.Id == Id));
        return result;
    }
}
