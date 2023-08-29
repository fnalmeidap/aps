using Microsoft.AspNetCore.Mvc;
using Olimpo.Model;
using Olimpo.Repository;

namespace Olimpo.Controllers;

public class ParticipanteEquipeRequest
{
    public int EquipeId { get; set; }
    public int ParticipanteId { get; set; }
}

public class EquipeController 
{
    private static IRepositoryFactory _repositoryFactory = new RepositoryFactory();
    private static IRepository<Equipe> cadastroEquipes = _repositoryFactory.CreateEquipeMemoryRepository();
    //private static IRepository<Participante> cadastroParticipantes = _repositoryFactory.CreateParticipanteMemoryRepository();

    private static int generateId = 0;

    public IEnumerable<Equipe> GetEquipeList()
    {
        return cadastroEquipes.List;
    }

    public Equipe? GetEquipeById(int id)
    {
        var equipe = cadastroEquipes.FindById(id);
        return equipe;
    }

    public void CreateEquipe(Equipe equipe)
    {
        equipe.Id = generateId;
        generateId += 1;

        List<Participante> validMembers = new List<Participante>();
        /*
        foreach (var member in equipe.Members) {
            var participante = cadastroParticipantes.FindById(member.Id);
            if (participante != null) {
                validMembers.Add(participante);
            }
        }*/

        equipe.Members = validMembers;  
        cadastroEquipes.Add(equipe);
    }
    public bool DeleteEquipeById(int id)
    {
        var equipe = cadastroEquipes.FindById(id);
        if (equipe == null)
        {
            return false;
        }

        cadastroEquipes.Delete(equipe);
        return true;
    }

    public bool AddParticipanteToEquipe(ParticipanteEquipeRequest participanteEquipeRequest)
    {
        var equipeId = participanteEquipeRequest.EquipeId;
        var participanteId = participanteEquipeRequest.ParticipanteId;

        var equipe = cadastroEquipes.FindById(equipeId);
        if (equipe == null)
        {
            return false;
        }
        /*
        var participante = cadastroParticipantes.FindById(participanteId);
        if (participante == null)
        {
            return false;
        }

        equipe.Members.Add(participante);
        cadastroEquipes.Update(equipe);*/

        return true;
    }
}
