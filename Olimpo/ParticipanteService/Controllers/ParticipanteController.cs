using Microsoft.AspNetCore.Mvc;
using Olimpo.Repository;
using Olimpo.Models;

namespace Olimpo.Controllers;
public class ParticipanteController
{
    private static IRepository<Participante> cadastroParticipantes = ParticipantesRepository.GetInstance();
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
