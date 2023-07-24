using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace Olimpo.Controllers;

public class EventosController
{
    private static IRepository<Evento> cadastroEventos = EventosRepository.GetInstance();
    private static IRepository<Equipe> cadastroEquipes = EquipesRepository.GetInstance();
    private static int generateId = 0;

    public IEnumerable<Evento> GetEventosList()
    {
        return cadastroEventos.List;
    }

    public Evento? GetEventoById(int Id)
    {
        var evento = cadastroEventos.FindById(Id);
        return evento;
    }
    public void CreateEvento(Evento evento)
    {
        evento.Id = generateId;
        generateId += 1;

        cadastroEventos.Add(evento);
    }

    public Evento? DeleteEventoById(int id)
    {
        var participante = cadastroEventos.FindById(id);
        if (participante != null)
        {
            cadastroEventos.Delete(participante);
        }
        return participante;
    }
    public bool AddEquipeToEvento(EquipeData equipeData)
    {
        var eventoId = equipeData.EventoId;
        var equipeId = equipeData.EquipeId;
        var categorias = equipeData.Categorias;

        var evento = cadastroEventos.FindById(eventoId);
        if (evento == null)
        {
            return false;
        }

        var equipe = cadastroEquipes.FindById(equipeId);
        if (equipe == null)
        {
            return false;
        }

        if(categorias == null || categorias.Count == 0) {
            return false;
        }

        evento.Equipes.Add(equipeData);
        cadastroEventos.Update(evento);

        return true;
    }
        
}

