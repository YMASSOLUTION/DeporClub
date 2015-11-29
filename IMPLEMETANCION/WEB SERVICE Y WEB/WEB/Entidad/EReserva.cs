using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EReserva
    {
        public int id { get; set; }
        public string centrodeportivo { get; set; }

        public string  campo { get; set; }

        public string fecha { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
    }
}
