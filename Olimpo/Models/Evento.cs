namespace NetApi;

public enum CategoriasType {
    SMALL_SIZE_LEAGUE,
    SIMULATION_2D,
    SIMULATION_3D,
    VERY_SMALL_SIZE_SOCCER
}

    public class Evento
    {
    public Evento(int id, Endereco endereco, DateTime startTime, DateTime finalTime, CategoriasType[] categorias)
    {
        Id = id;
        Endereco = endereco;
        StartTime = startTime;
        FinalTime = finalTime;
        Categorias = categorias;
    }

    public int Id { get; private set; }
    public Endereco Endereco { get; private set; }

    public DateTime StartTime { get; private set; }
    public DateTime FinalTime { get; private set; }

    public CategoriasType[] Categorias { get; private set; }
}

