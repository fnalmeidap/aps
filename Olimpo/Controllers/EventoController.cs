using Microsoft.AspNetCore.Mvc;
using Olimpo.Model;
using Olimpo.Repository;

namespace Olimpo.Controllers;

public class InscricaoEquipeRequest
{
    public int EventoId { get; set; }
    public int EquipeId { get; set; }
    public List<CategoriasType> Categorias { get; set; }
}

public class EventoController
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

    public bool DeleteEventoById(int id)
    {
        var participante = cadastroEventos.FindById(id);
        if (participante != null)
        {
            cadastroEventos.Delete(participante);
        }
        return true;
    }

    public bool AddEquipeToEvento(InscricaoEquipeRequest inscricaoEquipeRequest)
    {
        var eventoId = inscricaoEquipeRequest.EventoId;
        var equipeId = inscricaoEquipeRequest.EquipeId;
        var categorias = inscricaoEquipeRequest.Categorias;

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

        evento.Equipes.Add(new InscricaoEvento {
            EquipeId = eventoId,
            Categorias = categorias,
        });
        cadastroEventos.Update(evento);

        return true;
    }
        
}

