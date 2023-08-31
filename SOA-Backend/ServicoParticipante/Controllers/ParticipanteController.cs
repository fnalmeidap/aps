using Microsoft.AspNetCore.Mvc;
using ServicoParticipante.Repository;
using ServicoParticipante.Model;

namespace ServicoParticipante.Controllers;
public class ParticipanteController
{
    private static IRepositoryFactory _repositoryFactory = new RepositoryFactory();
    private IRepository<Participante> cadastroParticipantes = _repositoryFactory.CreateParticipanteMemoryRepository();
    private static int generateId = 0;

    public IEnumerable<Participante> GetParticipanteList()
    {
        return cadastroParticipantes.List;
    }

    public Participante? GetParticipanteById(int Id)
    {
        var participante = cadastroParticipantes.FindById(Id);
        return participante;
    }

    public void CreateParticipante(Participante participante)
    {
        participante.Id = generateId;
        generateId += 1;

        cadastroParticipantes.Add(participante);
    }
    public bool DeleteParticipanteById(int id)
    {
        var participante = cadastroParticipantes.FindById(id);
        if (participante == null)
        {
            return false;
        }

        cadastroParticipantes.Delete(participante);
        return true;
    }
}
