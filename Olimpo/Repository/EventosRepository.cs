using Olimpo.Model;
using System.Linq;

namespace Olimpo.Repository;
public class EventosRepository : IRepository<Evento>
{

    private List<Evento> cadastroEventos { get; set; }

    private static EventosRepository Instance = null;

    public static EventosRepository GetInstance()
    {
        if (Instance == null)
        {
            Instance = new EventosRepository();
        }
        return Instance;
    }

    private EventosRepository()
    {
        cadastroEventos = new List<Evento>();

    }

    public IEnumerable<Evento> List
    {
        get
        {
            return cadastroEventos;
        }

    }

    public void Add(Evento entity)
    {
        cadastroEventos.Add(entity);
    }

    public void Delete(Evento entity)
    {
        cadastroEventos.Remove(entity);
    }

    public void Update(Evento entity)
    {
        cadastroEventos.Remove(entity);
        cadastroEventos.Add(entity);
    }

    public Evento? FindById(int Id)
    {
        var result = (cadastroEventos.FirstOrDefault(p => p.Id == Id));
        return result;
    }
    public IEnumerable<Evento> FindAll(int Id)
    {
        var result = (cadastroEventos.FindAll(p => p.Id == Id));
        return result;
    }
    public Evento? FindByPredicate(Func<Evento, bool> predicate)
    {
        var result = (cadastroEventos.FirstOrDefault(predicate));
        return result;
    }
}
