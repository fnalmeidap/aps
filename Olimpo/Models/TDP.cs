namespace NetApi;

public class TDP
{
    public TDP(int equipeId, byte[] arquivo, CategoriasType categoria)
    {
        EquipeId = equipeId;
        Categoria = categoria;
        Arquivo = arquivo;
        UltimaVezModificado = DateTime.Now;
    }
    
    public int EquipeId { get; private set; } 
    public CategoriasType Categoria { get; private set; }
    public byte[] Arquivo { get; private set; }
    public DateTime UltimaVezModificado { get; private set; }
}
