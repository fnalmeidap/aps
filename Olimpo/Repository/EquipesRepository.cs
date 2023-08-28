using Olimpo.Models;

namespace Olimpo.Repository;
public class EquipesRepository : IRepository<Equipe>
{

    private List<Equipe> cadastroEquipes { get; set; }

    private static EquipesRepository Instance = null;

    public static EquipesRepository GetInstance()
    {
        if (Instance == null)
        {
            Instance = new EquipesRepository();
        }
        return Instance;
    }

    private EquipesRepository()
    {
        cadastroEquipes = new List<Equipe>();

    }

    public IEnumerable<Equipe> List
    {
        get
        {
            return cadastroEquipes;
        }

    }

    public void Add(Equipe entity)
    {
        cadastroEquipes.Add(entity);
    }

    public void Delete(Equipe entity)
    {
        cadastroEquipes.Remove(entity);
    }

    public void Update(Equipe entity)
    {
        cadastroEquipes.Remove(entity);
        cadastroEquipes.Add(entity);
    }

    public Equipe? FindById(int Id)
    {
        var result = (cadastroEquipes.FirstOrDefault(p => p.Id == Id));
        return result;
    }
    public IEnumerable<Equipe> FindAll(int Id)
    {
        var result = (cadastroEquipes.FindAll(p => p.Id == Id));
        return result;
    }

    public Equipe? FindByPredicate(Func<Equipe, bool> predicate)
    {
        var result = (cadastroEquipes.FirstOrDefault(predicate));
        return result;
    }
}
