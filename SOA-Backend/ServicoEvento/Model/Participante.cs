using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServicoEvento.Model;

[Table("Participante")]
public partial class Participante : EntidadeBase
{
    [Required]
    public string TokenId { get; set; }

    [Required]
    public string GoogleId { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string University { get; set; }
    
    [Required]
    public DateTime BirthDay { get; set; }
}