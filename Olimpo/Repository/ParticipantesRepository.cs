using Olimpo.Models;

namespace Olimpo.Repository;
public class ParticipantesRepository : IRepository<Participante>
{

    private static List<Participante> cadastroParticipantes { get; set; }

    public ParticipantesRepository()
    {
        cadastroParticipantes = new List<Participante>();

    }

    public IEnumerable<Participante> List
    {
        get
        {
            return cadastroParticipantes;
        }

    }

    public void Add(Participante entity)
    {
        cadastroParticipantes.Add(entity);
    }

    public void Delete(Participante entity)
    {
        cadastroParticipantes.Remove(entity);
    }

    public void Update(Participante entity)
    {
        cadastroParticipantes.Remove(entity);
        cadastroParticipantes.Add(entity);
    }

    public Participante? FindById(int Id)
    {
        var result = (cadastroParticipantes.FirstOrDefault(p => p.Id == Id));
        return result;
    }

    public IEnumerable<Participante> FindAll(int Id)
    {
        var result = (cadastroParticipantes.FindAll(p => p.Id == Id));
        return result;
    }
}
