using Olimpo.Models;

namespace Olimpo.Repository;
public class ParticipantesRepository : IRepository<Participante>
{

    private static List<Participante> cadatroParticipantes { get; set; }

    public ParticipantesRepository()
    {
        cadatroParticipantes = new List<Participante>();

    }

    public IEnumerable<Participante> List
    {
        get
        {
            return cadatroParticipantes;
        }

    }

    public void Add(Participante entity)
    {
        cadatroParticipantes.Add(entity);
    }

    public void Delete(Participante entity)
    {
        cadatroParticipantes.Remove(entity);
    }

    public void Update(Participante entity)
    {
        cadatroParticipantes.Remove(entity);
        cadatroParticipantes.Add(entity);
    }

    public Participante? FindById(int Id)
    {
        var result = (cadatroParticipantes.FirstOrDefault(p => p.Id == Id));
        return result;
    }

    public IEnumerable<Participante> FindAll(int Id)
    {
        var result = (cadatroParticipantes.FindAll(p => p.Id == Id));
        return result;
    }
}
