using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Olimpo.Models
{
    public class ParticipanteEquipe
    {
        public Participante? Participante { get;  set; }

        public Equipe? Equipe { get;  set; }

        public ParticipanteEquipe(Participante? participante, Equipe? equipe) { 
            Participante = participante;
            Equipe = equipe;

        }
    }
}
