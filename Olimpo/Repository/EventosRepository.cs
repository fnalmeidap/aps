using Olimpo.Models;

namespace Olimpo.Repository;
public class EventosRepository : IRepository<Evento>
{

    private static List<Evento> cadastroEventos { get; set; }

    public EventosRepository()
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
}
