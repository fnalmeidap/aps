using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Olimpo.Model;

public enum CategoriasType {
    NONE,
    SMALL_SIZE_LEAGUE,
    SIMULATION_2D,
    SIMULATION_3D,
    VERY_SMALL_SIZE_SOCCER
}

public class InscricaoEvento
{
    public int EquipeId { get; set; }
    
    public List<CategoriasType> Categorias { get; set; }
}

[Table("Evento")]
public partial class Evento : EntidadeBase
{
    public Evento()
    {
        Equipes = new List<InscricaoEvento>();
    }

    [Required]
    public string Name { get; set; }

    [Required]
    public Endereco Endereco { get; set; }
    
    [Required]
    public DateTime StartTime { get; set; }
    
    [Required]
    public DateTime FinalTime { get; set; }
    
    [Required]
    public List<CategoriasType> Categorias { get; set; }

    public List<InscricaoEvento> Equipes { get; set; }
}

