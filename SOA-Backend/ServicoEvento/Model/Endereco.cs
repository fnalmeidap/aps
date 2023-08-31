
namespace ServicoEvento.Model
{
    public class Endereco
    {
        public Endereco(string cidade, string estado, string pais)
        {
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }
    }
}
