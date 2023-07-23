using Olimpo.Models;

namespace Olimpo.Repository;
public class EventosRepository : IRepository<Evento>
{

    private static List<Evento> cadatroEventos { get; set; }

    public EventosRepository()
    {
        cadatroEventos = new List<Evento>();

    }

    public IEnumerable<Evento> List
    {
        get
        {
            return cadatroEventos;
        }

    }

    public void Add(Evento entity)
    {
        cadatroEventos.Add(entity);
    }

    public void Delete(Evento entity)
    {
        cadatroEventos.Remove(entity);
    }

    public void Update(Evento entity)
    {
        cadatroEventos.Remove(entity);
        cadatroEventos.Add(entity);
    }

    public Evento? FindById(int Id)
    {
        var result = (cadatroEventos.FirstOrDefault(p => p.Id == Id));
        return result;
    }
    public IEnumerable<Evento> FindAll(int Id)
    {
        var result = (cadatroEventos.FindAll(p => p.Id == Id));
        return result;
    }
}
