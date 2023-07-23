namespace Olimpo;

public class Equipe
{
    public required string Name { get; set; }
    public required string University { get; set; }
    public required List<Participante> Members { get; set; }
}
