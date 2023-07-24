using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Olimpo.Models;

[Table("TDP")]
public partial class TDP : EntidadeBase
    {
    [Required]
    public int EquipeId { get; set; }

    [Required]
    public int EventoId { get; set; }

    [Required]
    public CategoriasType Categoria { get; set; }

    [Required]
    public List<byte> Arquivo { get; set; }
    
    [Required]
    public DateTime UltimaVezModificado { get; set; }
}
