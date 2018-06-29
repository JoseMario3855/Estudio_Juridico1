using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Sicafi.Listas
{
    public class Consultar_ZonasEconomicas_Result
    {
        public string strNufi { get; set; }
        public string strZonaEconomica { get; set; }
        public string strPorcentaje { get; set; }
        public string strDescripcion { get; set; }
        public decimal AreaZona { get; set; }
        public decimal ValorZona { get; set; }
        public decimal ValorZonaTotal { get; set; }

    }
}
