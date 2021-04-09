using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliziaVeronica
{
    class Agente : Persona
    {
        public int IdAgente { get; }
        public int AnniServizio { get; }
        public DateTime DataNascita { get; }

        public Agente (int idAgente, string nome, string cognome, string codiceFiscale, int anniServizio, DateTime dataNascita) : base(nome, cognome, codiceFiscale)
        {
            IdAgente = idAgente;
            AnniServizio = anniServizio;
            DataNascita = dataNascita;
        }
        public override string ToString()
        {
            return $"Codice Fiscale: {CodiceFiscale}, Nome e cognome : {Nome} {Cognome}, {AnniServizio} anni di servizio";
        }
    }
}
