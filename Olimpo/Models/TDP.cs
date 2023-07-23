using Olimpo.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Olimpo.Models;


[Table("TDP")]
public partial class TDP : EntidadeBase
    {
    [Required]
    public int EquipeId { get; private set; }
    [Required]
    public CategoriasType Categoria { get; private set; }
    [Required]
    public byte[] Arquivo { get; private set; }
    [Required]
    public DateTime UltimaVezModificado { get; private set; }
}
