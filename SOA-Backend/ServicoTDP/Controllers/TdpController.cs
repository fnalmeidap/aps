using Microsoft.AspNetCore.Mvc;
using ServicoTDP.Model;
using ServicoTDP.Repository;
using ServicoTDP.Web;

namespace ServicoTDP.Controllers;

public class TdpController
{
    private static IRepository<TDP> cadastroTdps = TDPRepository.GetInstance();
    private EquipeService _equipeService = new EquipeService("http://localhost:5211/api");
    private EventoService _eventoService = new EventoService("http://localhost:5211/api");
    private static int generateId = 0;

    public IEnumerable<TDP> GetTDPList()
    {
        return cadastroTdps.List;
    }

    public TDP? GetTDPByEquipe(int equipeId)
    {
        var equipeTdps = cadastroTdps.FindByPredicate(t => 
            t.EquipeId == equipeId);

        return equipeTdps;
    }

    public bool atualizarTDP(TDP tdp)
    {
        var oldTdp = cadastroTdps.FindById(tdp.Id);
        if (oldTdp == null)
        {
            return false;
        }
        cadastroTdps.Update(tdp);
        return true;
    }

    public TDP? GetTDPByEquipeCategoria(int equipeId, CategoriasType categoria)
    {
        var equipeTdps = cadastroTdps.FindByPredicate(t => 
            t.EquipeId == equipeId &&
            t.Categoria == categoria);

        return equipeTdps;
    }

    public IEnumerable<TDP> buscarTDPsEmEvento(int eventoId)
    {
        return cadastroTdps.List.Where(t => t.EventoId == eventoId);
    }


    public TDP? GetTDPById(int id)
    {
        var equipeTdps = cadastroTdps.FindById(id);

        return equipeTdps;
    }

    public bool CreateTdp(TDP tdp)
    {
        var evento = _eventoService.FindEventoById(tdp.EventoId);
        if (evento == null)
        {
            return false;
        }

        var equipe = _equipeService.FindEquipeById(tdp.EquipeId);
        if (equipe == null)
        {
            return false;
        }

        tdp.Id = generateId;
        generateId += 1;

        cadastroTdps.Add(tdp);
        
        return true;
    }

    public bool DeleteTdpById(int equipeId, CategoriasType categoria)
    {
        var equipeTdps = cadastroTdps.FindByPredicate(t => 
            t.EquipeId == equipeId &&
            t.Categoria == categoria);

        if (equipeTdps == null)
        {
            return false;
        }

        cadastroTdps.Delete(equipeTdps);
        return true;
    }
}

