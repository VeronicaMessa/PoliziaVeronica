using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliziaVeronica
{
   abstract class Persona
    {
        public string Nome { get; }
        public string Cognome { get;  }
        public string CodiceFiscale { get;  }

        public Persona (string nome, string cognome, string codiceFiscale)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codiceFiscale; 
        }
        public static bool operator ==(Persona p1, Persona p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Persona p1, Persona p2)
        {
            return !p1.Equals(p2);
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            return CodiceFiscale == ((Persona)obj).CodiceFiscale;
        }

        public override int GetHashCode()
        {
            return CodiceFiscale.GetHashCode();
        }
    }
}
