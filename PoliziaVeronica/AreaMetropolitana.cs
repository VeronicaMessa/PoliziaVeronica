using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliziaVeronica
{
    class AreaMetropolitana
    {
        public int IdArea { get; }
        public string CodiceArea { get; }
        public bool AltoRischio { get; }

        public List<Agente> Agenti { get; } = new List<Agente>();

        public AreaMetropolitana (int idArea, string codiceArea, bool altoRischio)
        {
            IdArea = idArea;
            CodiceArea = codiceArea;
            AltoRischio = altoRischio; 
        }
    }
}
