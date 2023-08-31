using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ServicoTDP.Model;

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
    public string Arquivo { get; set; }
    
    [Required]
    public DateTime UltimaVezModificado { get; set; }
}
