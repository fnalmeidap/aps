using Olimpo.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Olimpo.Models;

[Table("Participante")]
public partial class Participante : EntidadeBase
{
    [Required]
    public string TokenId { get; private set; }
    [Required]
    public string Name { get; private set; }
    [Required]
    public string Email { get; private set; }
    [Required]
    public string University { get; private set; }
    [Required]
    public DateTime BirthDay { get; private set; }
}
