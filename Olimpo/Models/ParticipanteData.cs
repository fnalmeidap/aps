using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Olimpo.Models;

public class ParticipanteData
{
    public int EquipeId { get; set; }
    public int ParticipanteId { get; set; }
}