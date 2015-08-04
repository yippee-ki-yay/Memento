using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    /// <summary>
    /// Ako belezimo sta si znao/nisi umesto onog Tuple<string, string> mozemo cuvati kao QaPair gde imamo i info
    /// o drugim stvarimo pored ovih pitanja
    /// </summary>
    class QaPair
    {
        string odgovor {get; set;}
        string pitanja { get; set; }
        int broj_pogodjenih { get; set; }
        int broj_promasenih { get; set; }
        int ocena { get; set; }
    }
}
