using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Olimpo.Models;

public class EquipeData
{
    public int EventoId { get; set; }
    public int EquipeId { get; set; }
    public List<CategoriasType> Categorias { get; set; }
}