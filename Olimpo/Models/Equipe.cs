using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Olimpo.Models;

[Table("Equipe")]
public partial class Equipe : EntidadeBase
{
    [Required]
    public string Name { get; private set; }
    [Required]
    public string University { get; private set; }
    [Required]
    public  List<Participante> Members { get; private set; }
}