using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace Olimpo.Controllers;

public class EquipeController 
{
    private static IRepository<Equipe> cadastroEquipes = EquipesRepository.GetInstance();
    private static IRepository<Participante> cadastroParticipantes = ParticipantesRepository.GetInstance();

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
        foreach (var member in equipe.Members) {
            var participante = cadastroParticipantes.FindById(member.Id);
            if (participante != null) {
                validMembers.Add(participante);
            }
        }

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

    public bool AddParticipanteToEquipe(ParticipanteData participanteData)
    {
        var equipeId = participanteData.EquipeId;
        var participanteId = participanteData.ParticipanteId;

        var equipe = cadastroEquipes.FindById(equipeId);
        if (equipe == null)
        {
            return false;
        }

        var participante = cadastroParticipantes.FindById(participanteId);
        if (participante == null)
        {
            return false;
        }

        equipe.Members.Add(participante);
        cadastroEquipes.Update(equipe);

        return true;
    }
}
