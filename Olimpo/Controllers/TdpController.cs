using Microsoft.AspNetCore.Mvc;
using Olimpo.Models;
using Olimpo.Repository;

namespace Olimpo.Controllers;

public class TdpController
{
    private static IRepository<TDP> cadastroTdps= new TdpsRepository();
    private static int generateId = 0;

    public IEnumerable<TDP> GetTDPList()
    {
        return cadastroTdps.List;
    }

    public TDP? GetTDPByEquipe(int equipeId)
    {
        Console.WriteLine(cadastroTdps.List.First().EquipeId);
        Console.WriteLine(equipeId);
        var equipeTdps = cadastroTdps.FindByPredicate(t => 
            t.EquipeId == equipeId);

        return equipeTdps;
    }

    public TDP? GetTDPByEquipeCategoria(int equipeId, CategoriasType categoria)
    {
        var equipeTdps = cadastroTdps.FindByPredicate(t => 
            t.EquipeId == equipeId &&
            t.Categoria == categoria);

        return equipeTdps;
    }

    public void CreateTdp(TDP tdp)
    {
        tdp.Id = generateId;
        generateId += 1;

        cadastroTdps.Add(tdp);
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

