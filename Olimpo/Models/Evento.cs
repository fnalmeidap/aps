using Olimpo.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Olimpo.Models;

public enum CategoriasType {
    SMALL_SIZE_LEAGUE,
    SIMULATION_2D,
    SIMULATION_3D,
    VERY_SMALL_SIZE_SOCCER
}

    [Table("Evento")]
    public partial class Evento : EntidadeBase
    {
    [Required]
    public Endereco Endereco { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime FinalTime { get; set; }
    [Required]
    public int[] Categorias { get; set; }
}

