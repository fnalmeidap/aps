
namespace Olimpo.Utils
{
    public class Endereco
    {

        public Endereco(string cidade, string estado, string pais)
        {
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public string Pais { get; private set; }
    }
}
